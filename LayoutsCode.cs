using System;

using Xamarin.Forms;

namespace XFLayout
{
	public class LayoutPage : TabbedPage
	{
		public LayoutPage()
		{
			Children.Add(new StackLayoutPage());
			Children.Add(new AbsoluteLayoutPage());
			Children.Add(new RelativeLayoutPage());
			Children.Add(new GridLayoutPage());
			Children.Add(new ContentViewLayoutPage());
			Children.Add(new ScrollViewLayoutPage());
			Children.Add(new FrameLayoutPage());
		}
	}

	/* ----------------------------------------------------------------------------------------------------------
	 * STACKLAYOUT
	 * ----------------------------------------------------------------------------------------------------------
	*/
	public class StackLayoutPage : ContentPage
	{
		public StackLayoutPage()
		{
			//var stack = new StackLayout
			//{
			//	Padding = new Thickness(0, 20, 0, 0),
			//	Children =
			//	{
			//		//left, top, right, and bottom sides of the element
			//		new Label { Text = "Xamarin.Forms", Margin = new Thickness (20) },
			//		new Label { Text = "Xamarin.iOS", Margin = new Thickness (10, 25) },
			//		new Label { Text = "Xamarin.Android", Margin = new Thickness (0, 20, 15, 5) }
  			//	}
			//};


			var button = new Button
			{
				Text = "ini Button",
			};
			var label = new Label
			{
				Text = "ini Label",
				BackgroundColor = Color.Green,
				WidthRequest = 200,
				HeightRequest = 200,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};
			var entry = new Entry
			{
				Placeholder = "I have a entry box",
				BackgroundColor = Color.Green,
				WidthRequest = 200,
				HeightRequest = 150
			};
			var stack = new StackLayout
			{
				Children = { button, label, entry }
			};

			Padding = 20;
			Title = "Stack";
			Content = stack;

		}
	}

	/* ----------------------------------------------------------------------------------------------------------
	 * ABSOLUTELAYOUT
	 * ----------------------------------------------------------------------------------------------------------
	*/
	public class AbsoluteLayoutPage : ContentPage
	{
		public AbsoluteLayoutPage()
		{
			// Variabel
			var redBox = new BoxView
			{
				Color = Color.Red
			};
			var blueBox = new BoxView
			{
				Color = Color.Blue
			};
			var yellowBox = new BoxView
			{
				Color = Color.Yellow
			};
			var purpleBox = new BoxView
			{
				Color = Color.Purple
			};
			var greenBox = new BoxView
			{
				Color = Color.Green
			};

			AbsoluteLayout.SetLayoutFlags(redBox, AbsoluteLayoutFlags.All);
			AbsoluteLayout.SetLayoutBounds(redBox, new Rectangle(0, 0, 0.25, 0.25)); //posisi di screen
			AbsoluteLayout.SetLayoutFlags(blueBox, AbsoluteLayoutFlags.All);
			AbsoluteLayout.SetLayoutBounds(blueBox, new Rectangle(0.15, 0.15, 0.25, 0.25));
			AbsoluteLayout.SetLayoutFlags(yellowBox, AbsoluteLayoutFlags.All);
			AbsoluteLayout.SetLayoutBounds(yellowBox, new Rectangle(0.30, 0.30, 0.25, 0.25));
			AbsoluteLayout.SetLayoutFlags(purpleBox, AbsoluteLayoutFlags.All);
			AbsoluteLayout.SetLayoutBounds(purpleBox, new Rectangle(0.45, 0.45, 0.25, 0.25));
			AbsoluteLayout.SetLayoutFlags(greenBox, AbsoluteLayoutFlags.All);
			AbsoluteLayout.SetLayoutBounds(greenBox, new Rectangle(0.60, 0.60, 0.25, 0.25));

			Content = new AbsoluteLayout
			{
				Children = { redBox, blueBox, yellowBox, purpleBox, greenBox }
			};
			Title = "Absolute";
		}
	}

	/* ----------------------------------------------------------------------------------------------------------
	 * RELATIVELAYOUT
	 * ----------------------------------------------------------------------------------------------------------
	*/
	public class RelativeLayoutPage : ContentPage
	{
		public RelativeLayoutPage()
		{

			var redBox = new BoxView
			{
				Color = Color.Red
			};
			var blueBox = new BoxView
			{
				Color = Color.Blue
			};
			var yelowBox = new BoxView
			{
				Color = Color.Yellow
			};
			var purpleBox = new BoxView
			{
				Color = Color.Purple
			};


			var relativeLayout = new RelativeLayout();

			relativeLayout.Children.Add(redBox,
										Constraint.Constant(0),
										Constraint.Constant(0));
			relativeLayout.Children.Add(blueBox,
			                            Constraint.RelativeToParent((parent) => parent.Width - 40),
			                            Constraint.RelativeToParent((parent) => parent.Height - 40));
			relativeLayout.Children.Add(yelowBox,
			                            Constraint.RelativeToParent((parent) => parent.Width / 3),
			                            Constraint.RelativeToParent((parent) => parent.Height / 3),
			                            Constraint.RelativeToParent((parent) => parent.Width / 3),
			                            Constraint.RelativeToParent((parent) => parent.Height / 3));
			//purple di dalem yellwBox
			relativeLayout.Children.Add(purpleBox,
										Constraint.RelativeToView(yelowBox, (parent, sibling) => sibling.X),
										Constraint.RelativeToView(yelowBox, (parent, sibling) => sibling.Y),
										Constraint.RelativeToView(yelowBox, (parent, sibling) => sibling.Width / 3),
										Constraint.RelativeToView(yelowBox, (parent, sibling) => sibling.Height / 3));

			Title = "Relative";
			Content = relativeLayout;
		}
	}


	/* ----------------------------------------------------------------------------------------------------------
	 * GRIDLAYOUT
	 * ----------------------------------------------------------------------------------------------------------
	*/
	public class GridLayoutPage : ContentPage
	{
		public GridLayoutPage()
		{
			var grid = new Grid
			{
				RowDefinitions = new RowDefinitionCollection
				{
					new RowDefinition{Height = new GridLength(1,GridUnitType.Star)},
					new RowDefinition{Height = new GridLength(1,GridUnitType.Star)},
					new RowDefinition{Height = new GridLength(1,GridUnitType.Star)}
				},
				ColumnDefinitions = new ColumnDefinitionCollection
				{
					new ColumnDefinition{Width = new GridLength(1,GridUnitType.Star)},
					new ColumnDefinition{Width = new GridLength(1,GridUnitType.Star)},
					new ColumnDefinition{Width = new GridLength(1,GridUnitType.Star)}
				}
			};

			var label1 = new Label
			{
				Text = "Cell 0, 0",
				BackgroundColor = Color.Red,
				HorizontalTextAlignment = TextAlignment.Center,
				VerticalTextAlignment = TextAlignment.Center
			};
			var label2 = new Label
			{
				Text = "Cell 2, 2",
				BackgroundColor = Color.Green,
				HorizontalTextAlignment = TextAlignment.Center,
				VerticalTextAlignment = TextAlignment.Center
			};
			var label3 = new Label
			{
				Text = "Cell 1, 0 with span",
				BackgroundColor = Color.Blue,
				TextColor = Color.White,
				HorizontalTextAlignment = TextAlignment.Center,
				VerticalTextAlignment = TextAlignment.Center
			};

			// add to screen
			grid.Children.Add(label1, 0, 0); // atas kiri
			grid.Children.Add(label2, 2, 2); // bawah kanan
			grid.Children.Add(label3, 0, 1); // atas tengah

			//Grid.SetColumn(label3, 3);
			Grid.SetColumnSpan(label3, 3);

			Title = "Grid";
			Content = grid;
		}
	}

	/* ----------------------------------------------------------------------------------------------------------
	 * ContentView LAYOUT
	 * ----------------------------------------------------------------------------------------------------------
	*/
	public class ContentViewLayoutPage : ContentPage
	{
		public ContentViewLayoutPage()
		{
			var contentView = new ContentView
			{
				Content = new Label
				{
					Text = "Hi.. This is simple label from ContentViewLayoutPage",
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.Center
				}
			};

			Title = "Content View";
			Content = contentView; //show to screen
		}
	}

	/* ----------------------------------------------------------------------------------------------------------
	 * ScrollView LAYOUT
	 * ----------------------------------------------------------------------------------------------------------
	*/
	public class ScrollViewLayoutPage : ContentPage
	{
		public ScrollViewLayoutPage()
		{
			var scrollView = new ScrollView
			{
				Content = new Label
				{
					Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In ultrices eros turpis, aliquam luctus urna porta nec. Vivamus tempor nisl imperdiet leo gravida, imperdiet lobortis magna pellentesque. Proin tortor erat, dapibus sagittis felis vel, aliquet fermentum massa. Sed tincidunt dui eget blandit dignissim. Sed sed ante sed lectus eleifend finibus ut et massa. Vivamus mollis pretium nisi id ultricies. Maecenas quis tortor pulvinar, vehicula eros et, tincidunt tellus.\n\nPraesent eros quam, luctus a bibendum vitae, vulputate a leo. Vestibulum imperdiet dignissim augue, vel ullamcorper dolor fringilla ac. Donec quis nunc quam. Proin et lorem vel sapien pellentesque commodo. Sed lacinia ac urna id elementum. Mauris tempor orci et posuere rhoncus. Ut quis elit ac orci laoreet congue vel non leo. Interdum et malesuada fames ac ante ipsum primis in faucibus. Pellentesque consequat fringilla blandit. Nulla quis lacus ut turpis placerat auctor non hendrerit nibh.\n\nDonec interdum metus egestas orci facilisis dictum. Suspendisse quis orci metus. Ut commodo accumsan nunc, id vehicula purus pharetra et. Mauris facilisis maximus mi, a laoreet sem placerat quis. Cras facilisis, augue sed maximus vulputate, lacus lorem bibendum eros, sit amet pellentesque arcu tortor sit amet urna. Phasellus eleifend semper luctus. Pellentesque sit amet vehicula enim, ac hendrerit odio. Nunc aliquam, tellus eget consequat posuere, tellus risus laoreet nunc, nec scelerisque neque velit nec eros. Mauris iaculis lacus pretium neque rhoncus, sit amet ornare massa volutpat. Ut quis mi at magna fermentum vestibulum vitae nec metus. Donec convallis hendrerit tortor sed consequat. Vivamus est metus, placerat non nisl convallis, laoreet porttitor turpis. Vestibulum et elit at purus sollicitudin congue in quis nisl. Integer lorem augue, dictum vel laoreet quis, tristique sed leo. Proin maximus nibh at odio suscipit tempus volutpat ac purus. Donec ipsum orci, tristique non ante a, scelerisque pulvinar augue.\n\nPraesent malesuada nunc vel odio tempus, sed tempor risus consequat. Maecenas dignissim sit amet libero vel pharetra. Morbi id lectus tincidunt, rutrum massa malesuada, vestibulum arcu. Curabitur aliquam maximus consequat. Ut bibendum vel erat vel lacinia. Curabitur quis rutrum sem, eget pulvinar nisl. Aenean id scelerisque turpis. Vivamus porta auctor felis quis blandit. Aenean elementum est a molestie mollis. Sed pellentesque iaculis enim ut accumsan. Etiam placerat at elit in varius.\n\nFusce eu felis ac mi maximus varius. Fusce porttitor ligula in nisi malesuada semper. Proin vitae egestas nulla. Vivamus eget mi sit amet felis blandit bibendum ut nec ex. Maecenas erat nulla, pretium eu nisi quis, aliquet pretium tortor. Aliquam erat volutpat. Donec a est non diam ultrices feugiat. Cras ultricies congue nisl ac porttitor. Ut vel elit sit amet lacus finibus efficitur in eget lacus. Donec mollis eget lacus sodales porttitor."
				}


			};

			Title = "Scroll View";
			Content = scrollView;
		}
	}

	/* ----------------------------------------------------------------------------------------------------------
	 * FRAMELAYOUT
	 * ----------------------------------------------------------------------------------------------------------
	*/
	public class FrameLayoutPage : ContentPage
	{
		public FrameLayoutPage()
		{
			var frameView = new Frame
			{
				Content = new Label
				{
					Text = "I've been Framed!",
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.Center
				},
				OutlineColor = Color.Red
			};

			Title = "Frame";
			Content = frameView;

		}
	}
}
