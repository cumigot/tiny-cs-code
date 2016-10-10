private static Page myPage;

    public static Page GetMainPage()
    {
        myPage = new ContentPage
        {
            Content = new Label
            {
                Text = "Hello, Forms !",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            },
        };

        myPage.SizeChanged += myPage_SizeChanged;

        return myPage;
    }

    static void myPage_SizeChanged(object sender, EventArgs e)
    {
        Debug.WriteLine(myPage.Width + " " + myPage.Height);
    }
