namespace CatanMAUI.Views;

public partial class GamePage : ContentPage
{


	public GamePage()
	{
		InitializeComponent();
		GameField_StackLayout.Add(CreateHexagonLine(3,0));
		GameField_StackLayout.Add(CreateHexagonLine(4,100));
		GameField_StackLayout.Add(CreateHexagonLine(5,200));
        GameField_StackLayout.Add(CreateHexagonLine(4, 100));
        GameField_StackLayout.Add(CreateHexagonLine(3, 0));
    }

	public HorizontalStackLayout CreateHexagonLine(int length, int marginLeft)
	{
		var root = new HorizontalStackLayout()
		{
			Margin = new Thickness(0, 0, marginLeft, 0),
            MaximumHeightRequest = 200,
			MaximumWidthRequest = 200
			
        };
		root.HorizontalOptions= LayoutOptions.Center;
		for(int i = 0;i<length; i++)
		{
            root.Add(CreateHexagon());
        }
		

		return root;
    }
	public AbsoluteLayout CreateHexagon()
	{
		var root = new AbsoluteLayout();
		root.HeightRequest = 100;
        root.WidthRequest = 100;
        //root.Rotation = 90;

		var image = new Image();
		image.Source = "hexagon_desert.png";
        image.HeightRequest = 100;
        image.WidthRequest = 100;

        var button = new Button();
		button.HeightRequest = 60;
		button.WidthRequest = 60;
		button.BackgroundColor = Colors.Transparent;
		button.BorderColor = Colors.Transparent;

		//button.BorderColor = Colors.Yellow;

		var label = new Label()
		{
			Margin = new Thickness(0, 20, 0, 20)
			
        };
		label.Text = new Random().Next(1, 13).ToString();
		
        label.TextColor = Colors.Black;
		label.FontSize = 16;
		label.HorizontalOptions = LayoutOptions.Center;
		label.HorizontalTextAlignment = TextAlignment.Center;
		
		root.Add(image);
		root.Add(button);
		root.Add(label);
		root.SetLayoutBounds(image, new Rect(0, 0, 0, 0));
		root.SetLayoutBounds(button, new Rect(0, 0, 0, 0));
		



        return root;
	}


}