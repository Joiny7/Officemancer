// We've used jQuery since it came bundled in the installation.
// Feel free to change to change to a JS-lib of your choice.

function displayMonth(month) {
  $(".calendar_month header")
    .empty()
    .append("<h3>" + month + "</h3>");
}

function displayCalendar(days) {
  console.log(days);

  $("#calendar .calendar_month .dates").empty();

  for (let i = 0; i <= days.length; i++) {
    $("#calendar .calendar_month .dates").append(
      '<div class="date alert-success"><span class="registered">' +
        days[i].currentCapacity +
        "/" +
        days[i].maxCapacity +
        '</span><span class="day_of_month">' +
        (i + 1) +
        "</span></div>"
    );
  }
}

function login(user, pass) {
  $("#login_form").disabled;

  $.ajax(
    "https://officemancer.azurewebsites.net/user/login?username=" +
      user +
      "&password=" +
      pass +
      ""
  ).done(function (data) {
    if (data == "Success") {
      $("#login").fadeOut(function () {
        $("#calendar").fadeIn(function () {
          $("#logged_in_as").append(user);

          $.ajax(
            "https://officemancer.azurewebsites.net/user/getmonth?officeid=1&month=10&year=2020"
          ).done(function (data) {
            displayMonth(data.month);
            displayCalendar(data.days);
          });
        });
      });
    }
  });
}

$(document).ready(function () {
  $("#login_form").submit(function (e) {
    const user = $("#email").val();
    const pass = $("#password").val();

    login(user, pass);

    e.preventDefault();
  });
});
