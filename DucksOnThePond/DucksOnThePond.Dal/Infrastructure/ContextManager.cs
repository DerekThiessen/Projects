﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.Objects;
using System.Web;
using System.Threading;

  
namespace DucksOnThePond.Dal.Infrastructure
{
      /// <summary>
      /// Manages the lifecycle of the EF's object context
      /// </summary>
      /// <remarks>Uses a context per http request approach or one per thread in non web applications</remarks>
      public static class ContextManager
      {
          // accessed via lock(_threadObjectContexts), only required for multi threaded non web applications
          private static readonly Hashtable _threadObjectContexts = new Hashtable();
  
          public static IObjectSet<T> GetObjectSet<T>(T entity, string contextKey) 
              where T : class
          {
              return GetObjectContext(contextKey).CreateObjectSet<T>();
          }
  
          public static ObjectContext GetObjectContext(string contextKey)
          {
              ObjectContext objectContext = GetCurrentObjectContext(contextKey);
              if (objectContext == null) // create and store the object context
              {
                  //objectContext = new DmsEntities();
                  StoreCurrentObjectContext(objectContext, contextKey);
              }
              return objectContext;
          }
  
          public static object GetRepositoryContext(string contextKey)
          {
              return GetObjectContext(contextKey);
          }
  
          public static void SetRepositoryContext(object repositoryContext, string contextKey)
          {
              if (repositoryContext == null)
              {
                  RemoveCurrentObjectContext(contextKey);
              }
              else if (repositoryContext is ObjectContext)
              {
                  StoreCurrentObjectContext((ObjectContext)repositoryContext, contextKey);
              }
          }
  
          private static ObjectContext GetCurrentObjectContext(string contextKey)
          {
              ObjectContext objectContext = null;
              if (HttpContext.Current == null)
                  objectContext = GetCurrentThreadObjectContext(contextKey);
              else
                  objectContext = GetCurrentHttpContextObjectContext(contextKey);
              return objectContext;
          }
  
          private static void StoreCurrentObjectContext(ObjectContext objectContext, string contextKey)
          {
              if (HttpContext.Current == null)
                  StoreCurrentThreadObjectContext(objectContext, contextKey);
              else
                  StoreCurrentHttpContextObjectContext(objectContext, contextKey);
          }
  
          private static void RemoveCurrentObjectContext(string contextKey)
          {
              if (HttpContext.Current == null)
                  RemoveCurrentThreadObjectContext(contextKey);
              else
                  RemoveCurrentHttpContextObjectContext(contextKey);
          }
  
          private static ObjectContext GetCurrentHttpContextObjectContext(string contextKey)
          {
              ObjectContext objectContext = null;
              if (HttpContext.Current.Items.Contains(contextKey))
                  objectContext = (ObjectContext)HttpContext.Current.Items[contextKey];
              return objectContext;
          }
  
          private static void StoreCurrentHttpContextObjectContext(ObjectContext objectContext, string contextKey)
          {
              if (HttpContext.Current.Items.Contains(contextKey))
                  HttpContext.Current.Items[contextKey] = objectContext;
              else
                  HttpContext.Current.Items.Add(contextKey, objectContext);
          }

          private static void RemoveCurrentHttpContextObjectContext(string contextKey)
          {
              ObjectContext objectContext = GetCurrentHttpContextObjectContext(contextKey);
              if (objectContext != null)
              {
                  HttpContext.Current.Items.Remove(contextKey);
                  objectContext.Dispose();
              }
          }
  
          private static ObjectContext GetCurrentThreadObjectContext(string contextKey)
          {
              ObjectContext objectContext = null;
              Thread threadCurrent = Thread.CurrentThread;
              if (threadCurrent.Name == null)
                  threadCurrent.Name = contextKey;
              else
              {
                  object threadObjectContext = null;
                  lock (_threadObjectContexts.SyncRoot)
                  {
                      threadObjectContext = _threadObjectContexts[contextKey];
                  }
                  if (threadObjectContext != null)
                      objectContext = (ObjectContext)threadObjectContext;
              }
              return objectContext;
          }
  
          private static void StoreCurrentThreadObjectContext(ObjectContext objectContext, string contextKey)
          {
              lock (_threadObjectContexts.SyncRoot)
              {
                  if (_threadObjectContexts.Contains(contextKey))
                      _threadObjectContexts[contextKey] = objectContext;
                  else
                      _threadObjectContexts.Add(contextKey, objectContext);
              }
          }
  
          private static void RemoveCurrentThreadObjectContext(string contextKey)
          {
              lock (_threadObjectContexts.SyncRoot)
              {
                  if (_threadObjectContexts.Contains(contextKey))
                  {
                      ObjectContext objectContext = (ObjectContext)_threadObjectContexts[contextKey];
                      if (objectContext != null)
                      {
                          objectContext.Dispose();
                      }
                      _threadObjectContexts.Remove(contextKey);
                  }
              }
          }
      }
}