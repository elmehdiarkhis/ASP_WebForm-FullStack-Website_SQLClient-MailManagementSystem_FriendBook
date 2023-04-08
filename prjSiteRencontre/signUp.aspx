<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signUp.aspx.cs" Inherits="prjSiteRencontre.signUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RencontreAsp</title>

    <style>
		@import url('https://fonts.googleapis.com/css?family=Montserrat:400,800');

	

		* {
			box-sizing: border-box;
		}

		body {

			background-image: url('images/back.jpg');
			background-repeat: no-repeat;
			background-size:cover;
			background-attachment: fixed;

			display: flex;
			justify-content: center;
			align-items: center;
			flex-direction: column;
			font-family: 'Montserrat', sans-serif;
			height: 100vh;
			margin: -20px 0 50px;
		}

		h1 {
			font-weight: bold;
		}

		h2 {
			text-align: center;
		}

		p {
			font-size: 14px;
			font-weight: 100;
			line-height: 20px;
			letter-spacing: 0.5px;
			margin: 20px 0 30px;
		}

		span {
			font-size: 12px;
		}

		a {
			color: #333;
			font-size: 14px;
			text-decoration: none;
			margin: 15px 0;
		}

		.btn {
			border-radius: 20px;
			border: 1px solid #FF4B2B;
			background-color: #FF4B2B;
			color: #FFFFFF;
			font-size: 12px;
			font-weight: bold;
			padding: 12px 45px;
			letter-spacing: 1px;
			text-transform: uppercase;
			transition: transform 80ms ease-in;

			margin-top:40px;
		}

		.btn:active {
			transform: scale(0.95);
		}

		.btn:focus {
			outline: none;
		}

		.btn.ghost {
			background-color: transparent;
			border-color: #FFFFFF;
		}

		form {
			background-color: #FFFFFF;
			display: flex;
			justify-content: center;
			flex-direction: column;
			padding: 0 50px;
			height: 100%;
		}

		.txt {
			background-color: #eee;
			border: none;
			padding: 12px 15px;
			margin: 8px 0;
			width: 100%;
		}


		.container {
			background-color: #fff;
			border-radius: 10px;
  			box-shadow: 0 14px 28px rgba(0,0,0,0.25), 
					0 10px 10px rgba(0,0,0,0.22);
			position: relative;
			overflow: hidden;
			width: 768px;
			max-width: 100%;
			min-height: 800px;
			margin-top:100px;

			opacity:0.9;
		}

		.form-container {
			position: absolute;
			top: 0;
			height: 100%;
			transition: all 0.6s ease-in-out;
		}

		.sign-in-container {
			left: 0;
			width: 50%;
			z-index: 2;
			display: flex;
			flex-direction: column;
			justify-content: center;
			padding-left: 5%;
			padding-right: 5%;
		}

		.container.right-panel-active .sign-in-container {
			transform: translateX(100%);
		}

		.sign-up-container {
			left: 0;
			width: 50%;
			opacity: 0;
			z-index: 1;
		}

		.container.right-panel-active .sign-up-container {
			transform: translateX(100%);
			opacity: 1;
			z-index: 5;
			animation: show 0.6s;
		}

		@keyframes show {
			0%, 49.99% {
				opacity: 0;
				z-index: 1;
			}
	
			50%, 100% {
				opacity: 1;
				z-index: 5;
			}
		}

		.overlay-container {
			position: absolute;
			top: 0;
			left: 50%;
			width: 50%;
			height: 100%;
			overflow: hidden;
			transition: transform 0.6s ease-in-out;
			z-index: 100;
		}

		.container.right-panel-active .overlay-container{
			transform: translateX(-100%);
		}

		.overlay {
			background: #FF416C;
			background: -webkit-linear-gradient(to right, #FF4B2B, #FF416C);
			background: linear-gradient(to right, #FF4B2B, #FF416C);
			background-repeat: no-repeat;
			background-size: cover;
			background-position: 0 0;
			color: #FFFFFF;
			position: relative;
			left: -100%;
			height: 100%;
			width: 200%;
  			transform: translateX(0);
			transition: transform 0.6s ease-in-out;
		}

		.container.right-panel-active .overlay {
  			transform: translateX(50%);
		}

		.overlay-panel {
			position: absolute;
			display: flex;
			align-items: center;
			justify-content: center;
			flex-direction: column;
			padding: 0 40px;
			text-align: center;
			top: 0;
			height: 100%;
			width: 50%;
			transform: translateX(0);
			transition: transform 0.6s ease-in-out;
		}

		.overlay-left {
			transform: translateX(-20%);
		}

		.container.right-panel-active .overlay-left {
			transform: translateX(0);
		}

		.overlay-right {
			right: 0;
			transform: translateX(0);
		}

		.container.right-panel-active .overlay-right {
			transform: translateX(20%);
		}

		.social-container {
			margin: 20px 0;
		}

		.social-container a {
			border: 1px solid #DDDDDD;
			border-radius: 50%;
			display: inline-flex;
			justify-content: center;
			align-items: center;
			margin: 0 5px;
			height: 40px;
			width: 40px;
		}

		footer {
			background-color: #222;
			color: #fff;
			font-size: 14px;
			bottom: 0;
			position: fixed;
			left: 0;
			right: 0;
			text-align: center;
			z-index: 999;
		}

		footer p {
			margin: 10px 0;
		}

		footer i {
			color: red;
		}

		footer a {
			color: #3c97bf;
			text-decoration: none;
		}

		.RadioButtonListGenre{
			margin-bottom:5px;
		}

		.summary{
			font-size:10.5px;
		}
		.date{
			background-color:whitesmoke;
		}

    </style>
</head>


<body>

<div class="container" id="container">
	<form id="form2" runat="server">


		<div class="form-container sign-in-container">

			<h1>Create Account</h1>

			<asp:Label ID="lbl" runat="server">Ma Date de Naissance:</asp:Label>
			<div style="display:flex">
				<asp:TextBox ID="dateNaissance" AutoPostBack="true" runat="server" TextMode="Date" CssClass="txt"></asp:TextBox>
				<asp:RequiredFieldValidator Font-Bold="true" ForeColor="Red" ID="reqValAge" runat="server" ControlToValidate="dateNaissance" ErrorMessage="Veuillez entrer votre Age SVP !!" Text="*"></asp:RequiredFieldValidator>
			</div>
			<br />
			

			<asp:Label ID="Label1" runat="server">Je Suis:</asp:Label>
			<asp:RadioButtonList CssClass="RadioButtonListGenre" AutoPostBack="true" ID="RadioButtonListGenre" runat="server" RepeatDirection="Horizontal">
				<asp:ListItem Text="Femme"></asp:ListItem>
				<asp:ListItem Text="Homme"></asp:ListItem>
				<asp:ListItem Text="Autres"></asp:ListItem>
			</asp:RadioButtonList>
			<br />

			<asp:Label ID="Label3" runat="server">Ma Nationalité:</asp:Label>
			<asp:DropDownList ID="DropDownListNatio" AutoPostBack="true" runat="server"></asp:DropDownList>
			<br />

			<asp:Label ID="lblUserName" runat="server">User Name:</asp:Label>
			<div style="display:flex">
				<asp:TextBox ID="txtUserName" runat="server" CssClass="txt"></asp:TextBox>
				<asp:RequiredFieldValidator Font-Bold="true" ForeColor="Red" ID="reqValUserName" runat="server" ControlToValidate="txtUserName" ErrorMessage="Veuillez entrer votre User Name SVP !!" Text="*"></asp:RequiredFieldValidator>
			</div>


			<asp:Label ID="lblEmail" runat="server">Email:</asp:Label>
			<div style="display:flex">
				<asp:TextBox ID="txtEmail" runat="server" TextMode="Email" CssClass="txt"></asp:TextBox>
				<asp:RequiredFieldValidator Font-Bold="true" ForeColor="Red" ID="reqValEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Veuillez entrer votre Email SVP !!" Text="*"></asp:RequiredFieldValidator>
			</div>

			<asp:Label ID="lblPass" runat="server">Mots de Pass:</asp:Label>
			<div style="display:flex">
				<asp:TextBox ID="txtPass" runat="server" TextMode="Password" CssClass="txt"></asp:TextBox>
				<asp:RequiredFieldValidator Font-Bold="true" ForeColor="Red" ID="reqValPass" runat="server" ControlToValidate="txtPass" ErrorMessage="Veuillez entrer votre mot de Pass SVP !!" Text="*"></asp:RequiredFieldValidator>
			</div>

			<asp:Label ID="Label2" runat="server">Confirmer votre Mots de Pass:</asp:Label>
			<div style="display:flex">
				<asp:TextBox ID="txtPassConfirmation" runat="server" TextMode="Password" CssClass="txt"></asp:TextBox>
				<asp:RequiredFieldValidator Font-Bold="true" ForeColor="Red" ID="reqValConfirmPass" runat="server" ControlToValidate="txtPassConfirmation" ErrorMessage="Veuillez Confirmer votre mot de Pass SVP !!" Text="*"></asp:RequiredFieldValidator>
				<asp:CompareValidator  Font-Bold="true" ForeColor="Red" ID="CompareValidatorPass" runat="server" ControlToValidate="txtPassConfirmation" ControlToCompare="txtPass" ErrorMessage="le mots de passe de confirmation est incorrect , Veuillez Ressayer SVP !!" Text="*"></asp:CompareValidator>
			</div>


			<asp:Label ID="Label4" runat="server">Upload votre photo:</asp:Label>
			<asp:FileUpload ID="FileUpload1" runat="server" />
			<asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click"/>

			


			<asp:ValidationSummary CssClass="summary" ID="ValidationSummary1" Font-Bold="true" ForeColor="Red" runat="server"/>
			<asp:Label ID="lblErreur" CssClass="summary" Font-Bold="true" ForeColor="Red" runat="server"></asp:Label>

			<asp:Button ID="btnSignUp" runat="server" Text="Sign Up" CssClass="btn" OnClick="btnSignUp_Click"  />	
		</div>

	

	<div class="overlay-container">
		<div class="overlay">
			<div class="overlay-panel overlay-right">
				<h1>Welcome Back!</h1>
				<p>Enter your personal details and start journey with us</p>
<%--				<asp:Button ID="btnReturnToLogin" runat="server" Text="Go Back to Login" CssClass="btn ghost" OnClick="btnReturnToLogin_Click" />	--%>
			</div>
		</div>
	</div>


</form>
</div>


</body>
</html>
