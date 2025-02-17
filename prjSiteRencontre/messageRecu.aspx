﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="messageRecu.aspx.cs" Inherits="prjSiteRencontre.messageRecu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href='https://fonts.googleapis.com/css?family=Ubuntu' rel='stylesheet' type='text/css'/>
	
    <title></title>

    <style>
        @import url("https://fonts.googleapis.com/css?family=DM+Sans:400,500,700|Source+Sans+Pro:300,400,600,700&display=swap");


* {
 outline: none;
 box-sizing: border-box;
}

html {
 box-sizing: border-box;
 -webkit-font-smoothing: antialiased;
}

body {
 font-family: "Source Sans Pro", sans-serif;
 background-color: #373e57;
 color: #ccc8db;
}

.container {
 background-color: #151728;
 display: flex;
 max-width: 1600px;
 height: 100vh;
 overflow: hidden;
 margin: 0 auto;
}

.left-side {
 width: 260px;
 border-right: 1px solid #272a3a;
 display: flex;
 flex-direction: column;
 transition: 0.3s;
 background-color: #151728;
 overflow: auto;
 flex-shrink: 0;
 @media screen and (max-width: 930px) {
  &.active {
   z-index: 4;
   & > *:not(.logo) {
    opacity: 1;
    transition: 0.3s 0.2s;
   }
   .left-side-button svg:first-child {
    opacity: 0;
   }
   .left-side-button svg:last-child {
    transform: translate(-50%, -50%);
    opacity: 1;
   }
  }
  &:not(.active) {
   width: 56px;
   overflow: hidden;
   & > *:not(.logo):not(.left-side-button) {
    opacity: 0;
   }
   .logo {
    writing-mode: vertical-lr;
    transform: rotate(180deg);
    transform-origin: bottom;
    display: flex;
    align-items: center;
    margin-top: -10px;
   }
  }
 }
}

.right-side {
 width: 280px;
 flex-shrink: 0;
 margin-left: auto;
 overflow: auto;
 background-color: #151728;
 display: flex;
 flex-direction: column;
 @media screen and (max-width: 1210px) {
  position: fixed;
  right: 0;
  top: 0;
  transition: 0.3s;
  height: 100%;
  transform: translateX(280px);
  z-index: 4;

  &.active {
   transform: translatex(0);
  }
 }
}

.main {
 flex-grow: 1;
 display: flex;
 flex-direction: column;
 background-color: #181d2f;
}

.logo {
 font-family: "DM Sans", sans-serif;
 font-size: 15px;
 color: #fff;
 font-weight: 600;
 text-align: center;
 height: 68px;
 line-height: 68px;
 letter-spacing: 4px;
 position: sticky;
 top: 0;
 background: linear-gradient(
  to bottom,
  rgba(21, 23, 40, 1) 0%,
  rgba(21, 23, 40, 1) 76%,
  rgba(21, 23, 40, 0) 100%
 );
}

.side-title {
 font-family: "DM Sans", sans-serif;
 color: #5c5e6e;
 font-size: 15px;
 font-weight: 600;
 margin-bottom: 20px;
}

.side-wrapper {
 padding: 30px;
}

.side-menu {
 display: flex;
 flex-direction: column;
 font-size: 15px;
 white-space: nowrap;
 svg {
  margin-right: 16px;
  width: 16px;
 }
 a {
  text-decoration: none;
  color: #9c9cab;
  display: flex;
  align-items: center;
  &:hover {
   color: #fff;
  }
  &:not(:last-child) {
   margin-bottom: 20px;
  }
 }
}

.follow-me {
 text-decoration: none;
 font-size: 14px;
 display: flex;
 align-items: center;
 margin-top: auto;
 overflow: hidden;
 color: #9c9cab;
 padding: 0 20px;
 height: 52px;
 flex-shrink: 0;
 border-top: 1px solid #272a3a;
 position: relative;
 svg {
  width: 16px;
  height: 16px;
  margin-right: 8px;
 }
}

.follow-text {
 display: flex;
 align-items: center;
 transition: 0.3s;
}

.follow-me:hover {
 .follow-text {
  transform: translateY(100%);
 }
 .developer {
  top: 0;
 }
}

.developer {
 position: absolute;
 color: #fff;
 left: 0;
 top: -100%;
 display: flex;
 transition: 0.3s;
 padding: 0 20px;
 align-items: center;
 background-color: #272a3a;
 width: 100%;
 height: 100%;
}

.developer img {
 border-radius: 50%;
 width: 26px;
 height: 26px;
 object-fit: cover;
 margin-right: 10px;
}

.search-bar {
 height: 60px;
 background-color: #151728;
 z-index: 3;
 position: relative;
 input {
  height: 100%;
  width: 100%;
  display: block;
  background-color: transparent;
  border: none;
  padding: 0 54px;
  background-image: url("data:image/svg+xml;charset=UTF-8,%3csvg xmlns='http://www.w3.org/2000/svg' width='512' height='512'%3e%3cpath d='M508.9 478.7L360 330a201.6 201.6 0 0045.2-127.3C405.3 90.9 314.4 0 202.7 0S0 91 0 202.7s91 202.6 202.7 202.6c48.2 0 92.4-17 127.3-45.2L478.7 509c4.2 4.1 11 4.1 15 0l15.2-15.1c4.1-4.2 4.1-11 0-15zm-306.2-116c-88.3 0-160-71.8-160-160s71.7-160 160-160 160 71.7 160 160-71.8 160-160 160z' data-original='%23000000' class='active-path' data-old_color='%23000000' fill='%235C5D71'/%3e%3c/svg%3e");
  background-repeat: no-repeat;
  background-size: 16px;
  background-position: 25px 50%;
  color: #fff;
  font-family: "Source Sans Pro", sans-serif;
  font-weight: 600;
  &::placeholder {
   color: #5c5d71;
  }
 }
}

.main-container {
 padding: 20px;
 flex-grow: 1;
 overflow: auto;
 background-color: #24273b;
}

.profile {
 position: relative;
 min-height: 150px;
 max-height: 350px;
 z-index: 1;

 &-cover {
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  object-fit: cover;
  object-position: center;
  border-radius: 4px;
 }

 &:before {
  content: "";
  width: 100%;
  height: 100%;
  position: absolute;
  z-index: -1;
  left: 0;
  top: 0;
  background-image: url("https://images.unsplash.com/photo-1508247967583-7d982ea01526?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=2250&q=80");
  background-repeat: no-repeat;
  background-size: cover;
  background-position: center;
  filter: blur(50px);
  opacity: 0.7;
 }
}

.profile-menu {
 position: absolute;
 bottom: 0;
 padding-left: 200px;
 background: #151728;
 width: 100%;
 display: flex;
 border-radius: 0 0 4px 4px;
}

.profile-menu-link {
 padding: 20px 16px;
 color: #5c5e6e;
 transition: 0.3s;
 cursor: pointer;
 text-decoration:none;

 &.active,
 &:hover {
  color: #fff;
  background-color: #1b1d2e;
  border-bottom: 3px solid #1488fa;
 }
}

.profile-avatar {
 position: absolute;
 align-items: center;
 display: flex;
 z-index: 1;
 bottom: 16px;
 left: 24px;
}

.profile-img {
 width: 150px;
 height: 150px;
 border-radius: 50%;
 object-fit: cover;
 border: 3px solid #151728;
}

.profile-name {
 margin-left: 24px;
 margin-bottom: 24px;
 font-size: 22px;
 color: #fff;
 font-weight: 600;
 font-family: "DM Sans", sans-serif;
}

.timeline {
 display: flex;
 padding-top: 20px;
 position: relative;
 z-index: 2;
 &-left {
  width: 310px;
  flex-shrink: 0;
 }
 &-right {
  flex-grow: 1;
  padding-left: 20px;
 }
 @media screen and (max-width: 768px) {
  flex-wrap: wrap;
  flex-direction: column-reverse;
  &-right {
   padding-left: 0;
   margin-bottom: 20px;
  }
  &-left {
   width: 100%;
  }
 }
}

.box {
 background-color: #151728;
 border-radius: 4px;
 width:1000px;
 margin-left:50px;
}

.intro {
 padding: 20px;

 &-title {
  font-family: "DM Sans", sans-serif;
  color: #5c5e6e;
  font-weight: 600;
  font-size: 18px;
  display: flex;
  align-items: center;
  margin-bottom: 20px;
 }
 &-menu {
  background-color: #8f98a9;
  box-shadow: -8px 0 0 0 #8f98a9, 8px 0 0 0 #8f98a9;
  width: 5px;
  height: 5px;
  border: 0;
  padding: 0;
  border-radius: 50%;
  margin-left: auto;
  margin-right: 8px;
 }
}

.info {
 font-size: 15px;

 &-item {
  display: flex;
  color: #c3c5d5;
 }

 &-item + &-item {
  margin-top: 14px;
 }

 &-item a {
  margin-left: 6px;
  color: #1771d6;
  text-decoration: none;
 }

 &-item svg {
  width: 16px;
  margin-right: 10px;
 }
}

.event {
 position: relative;
 margin-top: 20px;
 padding: 10px;
}

.event-wrapper {
 position: relative;
}

.event-img {
 max-width: 100%;
 display: block;
 padding-bottom: 12px;
}

.event-date {
 position: absolute;
 left: 20px;
 top: 15px;
}

.event-month {
 background-color: #1687fa;
 padding: 7px 20px;
 font-weight: 600;
 font-family: "DM Sans", sans-serif;
 color: #fff;
 text-align: center;
 border-radius: 4px 4px 0 0;
}

.event-day {
 width: 100%;
 backdrop-filter: blur(4px);
 color: #fff;
 font-size: 22px;
 font-weight: 600;
 font-family: "DM Sans", sans-serif;
 background-color: rgba(0, 0, 0, 0.4);
 padding: 6px 0;
 text-align: center;
}

.event-title {
 color: #c3c5d5;
 margin-bottom: 5px;
 font-family: "DM Sans", sans-serif;
 font-weight: 600;
 padding: 0 14px;
}

.event-subtitle {
 color: #5c5e6e;
 font-family: "DM Sans", sans-serif;
 font-size: 13px;
 font-weight: 500;
 padding: 0 14px;
}

.pages {
 margin-top: 20px;
 padding: 20px;
}

.flex{
    display:flex;
    margin-bottom:10px;
    justify-content: center;
    align-items: center;
}

.user {
 display: flex;
 flex-direction:column;
 cursor: pointer;
}

.user + .user {
 margin-top: 18px;
}

.user-img {
 border-radius: 50%;
 width: 45px;
 height: 45px;
 margin-right: 15px;
 object-fit: cover;
 object-position: center;
}

.username {
 font-size: 15px;
 font-family: "DM Sans", sans-serif;
}

.status-menu {
 padding: 20px;
 display: flex;
 align-items: center;
 &-item {
  text-decoration: none;
  color: #ccc8db;
  padding: 10px 14px;
  line-height: 0.7;
  font-family: "DM Sans", sans-serif;
  font-weight: 500;
  border-radius: 20px;
  &.active,
  &:hover {
   background-color: #2e2e40;
   color: #fff;
  }
 }
 &-item + &-item {
  margin-left: 10px;
 }
 @media screen and (max-width: 500px) {
  font-size: 14px;
  &-item + &-item {
   margin-left: 0;
  }
 }
}

.status-img {
 width: 50px;
 height: 50px;
 object-fit: cover;
 border-radius: 50%;
 margin-right: 20px;
}

.status-main {
 padding: 0 20px;
 display: flex;
 align-items: center;
 border-bottom: 1px solid #272a3a;
 padding-bottom: 20px;
 flex-wrap: wrap;
}

.status-textarea {
 flex-grow: 1;
 background-color: transparent;
 border: none;
 resize: none;
 margin-top: 15px;
 color: #fff;
 max-width: calc(100% - 70px);
 &::placeholder {
  color: #5c5d71;
 }
}

.status-actions {
 display: flex;
 padding: 10px 20px;
}

.status-action {
 text-decoration: none;
 color: #ccc8db;
 margin-right: 20px;
 display: flex;
 align-items: center;
 svg {
  width: 16px;
  flex-shrink: 0;
  margin-right: 8px;
 }
 @media screen and (max-width: 1320px) {
  width: 16px;
  overflow: hidden;
  color: transparent;
  white-space: nowrap;
 }
}

.status-share {
 background-color: #1b86f9;
 border: none;
 color: #fff;
 border-radius: 4px;
 padding: 10px 20px;
 margin-left: auto;
 box-shadow: 0 0 20px #1b86f9;
 cursor: pointer;
}

.album {
 padding-top: 20px;
 margin-top: 20px;
 .status-main {
  border: none;
  display: flex;
 }
 .intro-menu {
  margin-bottom: auto;
  margin-top: 5px;
 }
}

.album-detail {
 width: calc(100% - 110px);
}

.album-title span {
 color: #1771d6;
 cursor: pointer;
}

.album-date {
 font-size: 15px;
 color: #595c6c;
 margin-top: 4px;
}

.album-content {
 padding: 0 20px 20px;
}

.album-photo {
 width: 100%;
 object-fit: cover;
 object-position: center;
 border-radius: 4px;
 margin-top: 10px;
}

.album-photos {
 display: flex;
 margin-top: 20px;
 max-height: 30vh;
}

.album-photos > .album-photo {
 width: 50%;
}

.album-right {
 width: 50%;
 margin-left: 10px;
 line-height: 0;
 display: flex;
 flex-direction: column;
 .album-photo {
  height: calc(50% - 10px);
 }
}

.album-actions {
 padding: 0 20px 20px;
}

.album-action {
 margin-right: 20px;
 text-decoration: none;
 color: #a2a4b4;
 display: inline-flex;
 align-items: center;
 font-weight: 600;
 &:hover {
  color: #fff;
 }
 svg {
  width: 16px;
  margin-right: 6px;
 }
}

.account-button {
 border: 0;
 background: 0;
 color: #64677a;
 padding: 0;
 cursor: pointer;
 position: relative;
}

.account-button svg {
 width: 20px;
}

.account-button:not(.right-side-button) + .account-button:before {
 position: absolute;
 right: 0px;
 top: -2px;
 background-color: #1b86f8;
 width: 8px;
 height: 8px;
 border-radius: 50%;
 content: "";
 border: 2px solid #151728;
}

.account-profile {
 width: 28px;
 height: 28px;
 border-radius: 50%;
 margin: 0 10px;
}

.account-user {
 display: inline-flex;
 align-items: center;
 color: #64677a;
 font-weight: 600;
 span {
  font-size: 10px;
  font-weight: normal;
 }
}

.account {
 height: 60px;
 display: flex;
 justify-content: space-evenly;
 align-items: center;
 position: sticky;
 top: 0;
 background-color: #151728;
 z-index: 3;
 flex-shrink: 0;
}

.stories {
 border-bottom: 1px solid #272a3a;
}
.stories .user-img {
 border: 2px solid #e2b96c;
}

.stories .album-date {
 font-family: "Source Sans Pro", sans-serif;
}

.user-status {
 background-color: #7fd222;
 width: 8px;
 height: 8px;
 border-radius: 50%;
 margin-left: auto;
 &.offline {
  background-color: #606a8d;
 }
 &.idle {
  background-color: #dd1c20;
 }
}

.user-status-Fake {
 margin-left: auto;
}

.contacts .username {
 display: flex;
 flex: 1;
 align-items: center;
}

.right-search svg {
 width: 16px;
 height: 16px;
}

.right-search {
 padding-right: 10px;
 display: flex;
 align-items: center;
 border-top: 1px solid #272a3a;
 position: sticky;
 bottom: 0;
 margin-top: auto;
}

.right-search input {
 padding-right: 10px;
}

.search-bar-svgs {
 color: #656679;
 display: flex;
}

.search-bar-svgs svg {
 margin-right: 16px;
}

.overlay {
 width: 100%;
 height: 100%;
 position: fixed;
 top: 0;
 left: 0;
 background-color: rgba(#24273b, 0.8);
 opacity: 0;
 visibility: hidden;
 pointer-events: none;
 transition: 0.3s;

 @media screen and (max-width: 1210px) {
  &.active {
   z-index: 3;
   opacity: 1;
   visibility: visible;
   pointer-events: all;
  }
 }
}

.linkButton{
    text-decoration:none;
}

.right-side-button {
 position: absolute;
 right: 0;
 top: 0;
 height: 100%;
 border: 0;
 width: 52px;
 background-color: #1e2031;
 border-left: 1px solid #272a3a;
 color: #fff;
 display: none;
 cursor: pointer;

 &:before {
  content: "";
  width: 10px;
  height: 10px;
  border-radius: 50%;
  position: absolute;
  background-color: #1b86f8;
  border: 2px solid #1e2031;
  top: 13px;
  right: 12px;
 }
 svg {
  width: 22px;
 }
 @media screen and (max-width: 1210px) {
  display: block;
 }
}



::-webkit-scrollbar {
  width: 10px;
  border-radius: 10px;
}

/* Track */
::-webkit-scrollbar-track {
  background: rgba(255, 255, 255, 0.01);
}

/* Handle */
::-webkit-scrollbar-thumb {
  background: rgba(255, 255, 255, 0.11);
  border-radius: 10px;
}

/* Handle on hover */
::-webkit-scrollbar-thumb:hover {
  background: rgba(255, 255, 255, 0.1);
}

    </style>

</head>


<body>
    <form id="form1" runat="server">

        <div class="container" x-data="{ rightSide: false, leftSide: false }">
  <div class="main">
    <div class="search-bar">
      <button class="right-side-button" @click="rightSide = !rightSide">
         <svg viewBox="0 0 24 24" width="24" height="24" stroke="currentColor" stroke-width="2" fill="none" stroke-linecap="round" stroke-linejoin="round" class="css-i6dzq1"><path d="M21 15a2 2 0 0 1-2 2H7l-4 4V5a2 2 0 0 1 2-2h14a2 2 0 0 1 2 2z"></path></svg>
      </button>
    </div>
    <div class="main-container">
      <div class="profile">
        <div class="profile-avatar">
          <asp:Image ID="img" CssClass="profile-img" runat="server"/>
          <asp:Label ID="lblUserName" CssClass="profile-name" runat="server"></asp:Label>
        </div>
        <img  alt="" class="profile-cover">


        <div class="profile-menu">
          <asp:LinkButton CssClass="profile-menu-link active" ID="btnMyProfile" runat="server" OnClick="btnMyProfile_Click" >My Profile
          </asp:LinkButton>

           <asp:LinkButton CssClass="profile-menu-link" ID="btnEnvoyerMessage" runat="server" OnClick="btnEnvoyerMessage_Click" >Envoyer Message
            </asp:LinkButton>  

            <asp:LinkButton CssClass="profile-menu-link" ID="btnMessageRecu" runat="server" OnClick="btnMessageRecu_Click">Messages Recu
            </asp:LinkButton> 

        </div>

      </div>
      <div class="timeline">
        <div class="timeline-left">



          <div class="pages box">
              <asp:GridView ID="GridViewMessageRecu" runat="server"></asp:GridView>
          </div>



        </div>

      </div>
    </div>
  </div>
  <div class="right-side" :class="{ 'active': rightSide }">
    <div class="account">

      <span class="account-user">
           <asp:Label ID="lblUserNameAccount" runat="server"></asp:Label>
           <asp:Image ID="imgProfile" CssClass="account-profile" runat="server"/>
          <asp:LinkButton CssClass="linkButton" ID="btnDisconnect" runat="server" OnClick="btnDisconnect_Click">
              <span style="color:red;font-weight:700">Disconnect</span>
          </asp:LinkButton>
           
      </span>

    </div>
  </div>

  <div class="overlay" @click="rightSide = false; leftSide = false" :class="{ 'active': rightSide || leftSide }"></div>
</div>








    </form>
</body></html>
