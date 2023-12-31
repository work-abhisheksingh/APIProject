$(document).ready(function () {
    // Attach a click event handler to the login button
    $("#loginButton").click(function () {
        // Add a CSS class to apply the desired animation
        $(this).addClass("animate__animated animate__bounce"); // Using Animate.css classes

        // You can also include additional animation options from Animate.css, for example:
        // $(this).addClass("animate__animated animate__bounceInLeft");

        // Wait for the animation to finish, then remove the animation class
        setTimeout(function () {
            $("#loginButton").removeClass("animate__animated animate__bounce");
        }, 1000); // Adjust the duration (in milliseconds) based on your animation length
    });

    // Attach a submit event handler to the login form
    $("#loginForm").submit(function (event) {
        // Prevent the default form submission
        event.preventDefault();

        // Perform client-side validation (you can add more validation logic as needed)
        var username = $("#Username").val();
        var password = $("#Password").val();

        if (!username || !password) {
            // Display an error message if either username or password is empty
            $("#errorMessage").text("Username and password are required.");
            return;
        }

        // Clear any previous error messages
        $("#errorMessage").text("");

        // Submit the form using AJAX
        $.ajax({
            type: "POST",
            url: "/Login/Authenticate", // Replace with the correct URL
            data: $(this).serialize(),
            success: function (data) {
                // Handle the success response (redirect, show a success message, etc.)
                window.location.href = data.redirectUrl; // Replace with your logic
            },
            error: function (xhr, status, error) {
                // Handle the error response (display an error message, etc.)
                var errorMessage = xhr.responseJSON ? xhr.responseJSON.errorMessage : "An error occurred.";
                $("#errorMessage").text(errorMessage);
            }
        });
    });
});
