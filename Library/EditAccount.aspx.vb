﻿
Partial Class Library_EditAccount
    Inherits System.Web.UI.Page
    Dim CurrentUserProfile As New ProfileBase

    'Note to self: Profile loading only works in the Load event, not the Prerender event.
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load




        'So, funny story about this section. 
        'According to the official MSDN documentation of Visual Studio 2010,
        'ASP.NET will allow you to access profile properties via Profile.City or what have you.
        'The way in which it does this is by creating an instance of the ProfileCommon class, 
        'which is a modified version of the ProfileBase class that has additional functionality
        '(so that you don't have to keep calling GetPropertyValue).
        'However, what MSDN doesn't tell you is that, while all ASP.NET projects will generate the 
        'ProfileCommon class, only one of the potential project templates actually connects the 
        'ProfileCommon class to the database. So, if, when you started your project, you selected 
        '"ASP.NET Web Application", this functionality is not present, and you have to access profile
        'information through repeated calls of GetPropertyValue, and the profile has to be accessed through
        'HttpContext instead of the autogenerated stuff. It's a pain in the you know what, but that's
        'why this particular section is so messy-looking.


        CurrentUserProfile = HttpContext.Current.Profile



        If Not (Page.IsPostBack) Then


            LibraryNameTextbox.Text = CurrentUserProfile.GetPropertyValue("FullName")
            AddressTextbox.Text = CurrentUserProfile.GetPropertyValue("Address")
            CityTextbox.Text = CurrentUserProfile.GetPropertyValue("City")
            StateTextbox.Text = CurrentUserProfile.GetPropertyValue("State")
            CountryTextbox.Text = CurrentUserProfile.GetPropertyValue("Country")
            ZipTextbox.Text = CurrentUserProfile.GetPropertyValue("Zip")
            PhoneTextbox.Text = CurrentUserProfile.GetPropertyValue("Phone")
            WebsiteTextbox.Text = CurrentUserProfile.GetPropertyValue("Website")
        End If


    End Sub


    Protected Sub SaveButton_Click(sender As Object, e As System.EventArgs) Handles SaveButton.Click

        CurrentUserProfile.SetPropertyValue("FullName", LibraryNameTextbox.Text)
        CurrentUserProfile.SetPropertyValue("Address", AddressTextbox.Text)
        CurrentUserProfile.SetPropertyValue("City", CityTextbox.Text)
        CurrentUserProfile.SetPropertyValue("State", StateTextbox.Text)
        CurrentUserProfile.SetPropertyValue("Country", CountryTextbox.Text)
        CurrentUserProfile.SetPropertyValue("Zip", ZipTextbox.Text)
        CurrentUserProfile.SetPropertyValue("Phone", PhoneTextbox.Text)
        CurrentUserProfile.SetPropertyValue("Website", WebsiteTextbox.Text)
        CurrentUserProfile.Save()


        SavedLabel.Visible = True



    End Sub


End Class
