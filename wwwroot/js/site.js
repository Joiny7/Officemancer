// We've used jQuery since it came bundled in the installation.
// Feel free to change to change to a JS-lib of your choice.

function login(user, pass) {
  // alert(user + " " + pass);
  $("#login").fadeOut(function () {
    $("#calendar").fadeIn();
  });
}

$(document).ready(function () {
  $("#login_form").submit(function (e) {
    // alert("Run login script");

    const user = $("#email").val();
    const pass = $("#password").val();

    login(user, pass);

    e.preventDefault();
  });
});
