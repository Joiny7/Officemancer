// We've used jQuery since it came bundled in the installation.
// Sinje jQuery is pretty outdated, feel free to change to change to a JS-lib of your choice.

let isAdmin = false;
let userID = null;
let displayPopUpClose = false;

function setAdmin(bool) {
  isAdmin = bool;
}

function setUserID(uid) {
  userID = uid;
}

function setDisplayPopUpClose(bool) {
  displayPopUpClose = bool;
}

function getLatestWarning(user) {
  $.ajax({
    method: "GET",
    url:
      "https://officemancer.azurewebsites.net/api/Users/GetLastestWarning?userid=" +
      user,

    statusCode: {
      200: function (data) {
        console.log(data);
        $("#warning").append(
          "<div class='alert alert-danger'>" + data.message + "</div>"
        );
      },
    },
  });
}

function updateOffice(
  adminID,
  officeID,
  officeName,
  totalCapacity,
  bannerMessage
) {
  //console.log(adminID, officeID, officeName, totalCapacity, bannerMessage);

  $.ajax({
    method: "POST",
    url:
      "https://officemancer.azurewebsites.net/api/Admin/UpdateOffice?AdminID=" +
      adminID +
      "&OfficeId=" +
      officeID +
      "&OfficeName=" +
      officeName +
      "&TotalCapacity=" +
      totalCapacity +
      "&BannerMessage=" +
      bannerMessage +
      "",
    statusCode: {
      500: function () {
        $(".popup p").remove();
        $(".popup").append(
          '<div class="alert alert-danger">Something went wrong</div>'
        );
        setDisplayPopUpClose(true);
      },
      200: function () {
        setDisplayPopUpClose(false);
        $(".popup").append(
          "<p>Saving your updates <i class='fas fa-spinner'></i></p>"
        );
        getMonth(officeID, 10, 2020);
      },
    },
  });
}

function closePopUp(how, msg) {
  if (how == "success") {
    $(".popup")
      .empty()
      .append('<div class="alert alert-success">' + msg + "</div>");
    setTimeout(function () {
      $("#overlay").fadeOut(300, function () {
        $(this).remove();
      });
    }, 800);
  } else {
    $("#overlay").fadeOut(300, function () {
      $(this).remove();
    });
  }
}

function getMonth(officeID, month, year) {
  $(".calendar_month .dates").empty();

  $.ajax({
    method: "POST",
    url:
      "https://officemancer.azurewebsites.net/api/User/GetMonth?officeID=" +
      officeID +
      "&month=" +
      month +
      "&year=" +
      year +
      "",
  }).done(function (data) {
    displayMonth(data.month);
    displayCalendar(data.days);
    closePopUp("success", "You're information is saved");
  });
}

function loginError() {
  $(".login_feedback").slideDown();
  $("#login_form :input").prop("disabled", false);
}

function makeReservation(user, date, officeID) {
  $(".popup button").prop("disabled", true);

  console.log(user + " " + date + " " + officeID);

  $.ajax({
    method: "POST",
    url:
      "https://officemancer.azurewebsites.net/api/User/BookReservation?FloorID=1&OfficeID=" +
      officeID +
      "&BookerID=" +
      user +
      "&Date=" +
      date +
      "&MancerIds=",
    statusCode: {
      500: function () {
        $(".popup p").remove();
        $(".popup").append(
          '<div class="alert alert-danger">Something went wrong</div>'
        );
        setDisplayPopUpClose(true);
      },
      200: function () {
        setDisplayPopUpClose(false);
        $(".popup").append(
          "<p>Saving your reservation <i class='fas fa-spinner'></i></p>"
        );
        getMonth(officeID, 10, 2020);
      },
    },
  });
}

function login(user) {
  getUser(user);
  $("#login").fadeOut(function () {
    $("#calendar").fadeIn(function () {
      $("#logged_in_as").append(user);

      getLatestWarning(userID);

      if (isAdmin) {
        $("#logged_in_as").append(
          '<a href="#" id="admin_tools"><i class="fas fa-cog"></i></a>'
        );

        $("#admin_tools").on("click touchstart", function (e) {
          showPopUp("admin_tools", "2020-10-22T20:01:22.6308516", 1);

          e.preventDefault();
        });
      }

      getMonth(1, 10, 2020);
    });
  });
}

function getUser(username) {
  $.ajax({
    method: "GET",
    url:
      "https://officemancer.azurewebsites.net/api/Users/GetUser?UserName=" +
      username +
      "",
  }).done(function (data) {
    setUserID(data.userID);
    setAdmin(data.admin);
  });
}

function showPopUp(type, date, officeID) {
  $("body").prepend('<div id="overlay"></div>');
  $("#overlay").fadeIn(300);

  if (type == "book") {
    $("#overlay").append(
      '<div class="popup text-center"><button class="btn btn-primary">Book this date <i class="fas fa-user-plus"></i></button></div>'
    );
    $(".popup button").on("click touchstart", function () {
      makeReservation(userID, date, officeID);
    });
  }

  if (type == "admin_tools") {
    setDisplayPopUpClose(true);
    $("#overlay").append(
      '<div class="popup text-center"><button class="btn btn-primary">Change capacity <i class="fas fa-user-plus"></i></button></div>'
    );
    $(".popup button").on("click", function () {
      $.ajax({
        method: "POST",
        url:
          "https://officemancer.azurewebsites.net/api/User/GetOffice?officeID=" +
          officeID +
          "",
        statusCode: {
          200: function (data) {
            console.log(data);
            $(".popup").append(
              '<form method="post" id="update_office_form"><div class="form-group"><label for="new_capacity">Max Capacity</label><input type="number" id="new_capacity" value="' +
                data.totalCapacity +
                '" /></div><div class="form-group"><label for="banner_message">Banner message</label><input type="text" id="banner_message" value="' +
                data.bannerMessage +
                '" /></div><div class="form-group"><label for="office_name">Office name</label><input type="text" id="office_name" value="' +
                data.officeName +
                '" /></label></div><div class="form-group"><input type="submit" value="Update" /></div></form>'
            );

            $("#update_office_form").submit(function (e) {
              const newCapacity = $("#new_capacity").val();
              const bannerMessage = $("#banner_message").val();
              const officeName = $("#office_name").val();

              updateOffice(
                userID,
                officeID,
                officeName,
                newCapacity,
                bannerMessage
              );

              e.preventDefault();
            });
          },
        },
      });
    });

    //makeReservation(userID, date, officeID);
  }

  if (displayPopUpClose) {
    $(".popup").prepend(
      '<a href="#" id="close_popup"><i class="fas fa-times"></i></a>'
    );
    $("#close_popup").on("click touchstart", function (e) {
      closePopUp("close");
      e.preventDefault();
    });
  }
}

function displayMonth(month) {
  $(".calendar_month header")
    .empty()
    .append("<h3>" + month + "</h3>");
}

function displayCalendar(days) {
  console.log(days);

  //$("#calendar .calendar_month .dates").empty();

  for (let i = 0; i < days.length; i++) {
    let alert_class = "alert-success";

    if (days[i].currentCapacity >= days[i].maxCapacity / 2) {
      alert_class = "alert-warning";
    }

    if (days[i].currentCapacity >= days[i].maxCapacity * 0.8) {
      alert_class = "alert-danger";
    }

    $("#calendar .calendar_month .dates").append(
      '<div class="date ' +
        alert_class +
        '" data-date="' +
        days[i].date +
        '" data-office-id="' +
        days[i].officeID +
        '"><span class="registered">' +
        days[i].currentCapacity +
        "/" +
        days[i].maxCapacity +
        '</span><span class="day_of_month">' +
        (i + 1) +
        "</span></div>"
    );
  }

  $(".date").each(function () {
    $(this).click(function () {
      const date = $(this).attr("data-date");
      const officeID = $(this).attr("data-office-id");

      showPopUp("book", date, officeID);
    });
  });
}

function loginSubmit(user, pass) {
  $("#login_form :input").prop("disabled", true);

  $.ajax({
    method: "POST",
    url:
      "https://officemancer.azurewebsites.net/api/User/Login?username=" +
      user +
      "&password=" +
      pass +
      "",
    statusCode: {
      400: function () {
        loginError();
      },
      200: function () {
        login(user);
      },
    },
  });
}

$(document).ready(function () {
  $("#login_form").submit(function (e) {
    const user = $("#email").val();
    const pass = $("#password").val();

    loginSubmit(user, pass);

    e.preventDefault();
  });
});
