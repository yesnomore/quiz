$(document).ready(function () {

    $("#form1").validate(
		{
		    rules:
			{

			    login:
				{
				    required: true
				},
			    pwd:
			    {
			        required: true
			    }
			},
		    messages:
		    {
		        login: "Please enter un login",
		        pwd: "Please enter a password."
		    },
		    submitHandler: function (form) {
		        var options = {
		            type: 'post',
		            url: '/Home/SignIn',
		            data: { login: $('#login').val(), pwd: $('#pwd').val() },
		            success: function (data) {
		                if (data["key"] == "OK")
		                    window.location.href = '/Quiz/';
		                else
		                    $("#error").append(data["message"]);
		            }
		        };
		        $(this).ajaxSubmit(options);
		        return false;
		    }
		});
});