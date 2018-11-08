$(function () {
    $.validator.methods.date = function (value, element) {
        return moment(value, "DD/MM/YYYY", true).isValid() || moment(value, "DD/MM/YYYY HH:mm", true).isValid()
        || moment(value, "DD/MM/YYYY H:mm", true).isValid();
    }
});

