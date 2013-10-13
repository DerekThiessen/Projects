function PlayerViewModel() {
    var self = this;

    self.FirstName = ko.observable("");
    self.LastName = ko.observable("");

    var Player = {
        FirstName: self.FirstName,
        LastName: self.LastName
    };

    self.Player = ko.observable();
    self.Players = ko.observableArray();

    $.ajax({
        url: '/DucksOnThePond/Controllers/RosterController/GetAllPlayers',
        cache: false,
        type: 'get',
        contentType: 'application/json; charset-utf-8',
        data: {},
        error: handeError,
        success: function (data) {
            alert('.');
            self.Players(data);
        }
    });
}

function handeError(request, status, error) {
    alert(error);
}

var viewModel = new PlayerViewModel();
ko.applyBindings(viewModel);