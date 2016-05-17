using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using RaysHotDogs.Core.Models;
using RaysHotDogs.Core.Service;
using RaysHotDogs.Utility;

namespace RaysHotDogs
{
    [Activity(Label = "Hot Dog Detail", MainLauncher = true)]
    public class HotDogDetailActivity : Activity
    {

        private ImageView hotDogImagetextView;
        private TextView hotDogNameTextView;
        private TextView shortDescriptionTextView;
        private TextView HotDogShortTextView;
        private TextView priceTextView;
        private EditText amoutEditText;
        private Button cancelButton;
        private Button orderButton;

        private HotDog selectedHotDog;
        private HotDogDataService dataService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.HotDogDetailView);

            HotDogDataService dataService = new HotDogDataService();
            selectedHotDog = dataService.GetHotDogbyId(1);

            FindViews();
            BindData();
            HandleEvents();
            // Create your application here
        }
        private void FindViews()
        {
            hotDogImagetextView = FindViewById<ImageView>(Resource.Id.hotDogImageView);
            hotDogNameTextView = FindViewById<TextView>(Resource.Id.HotDogNameTextView);
            HotDogShortTextView = FindViewById<TextView>(Resource.Id.HotDogShortTextView);
            shortDescriptionTextView = FindViewById<TextView>(Resource.Id.shortDescriptionTextView);
            priceTextView = FindViewById<TextView>(Resource.Id.priceTextView);
            amoutEditText = FindViewById<EditText>(Resource.Id.amountEditText);
            cancelButton= FindViewById<Button>(Resource.Id.cancelButton);
            orderButton = FindViewById<Button>(Resource.Id.orderButton);
        }

        private void BindData()
        {
            hotDogNameTextView.Text = selectedHotDog.Name;
            HotDogShortTextView.Text = selectedHotDog.ShortDescription;
            shortDescriptionTextView.Text = selectedHotDog.Description;
            priceTextView.Text = "Price: " + selectedHotDog.Price;

            var imageBitMap = ImageHelper.GetImageBitmapFromUrl("http://gillcleerenpluralsight.blob.core.windows.net/files/" + selectedHotDog.Imagepath+".jpg");
            hotDogImagetextView.SetImageBitmap(imageBitMap);
        }

        private void HandleEvents()
        {
            orderButton.Click += OrderButton_Click;
            cancelButton.Click += CancelButton_Click;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            //TODO
        }

        private void OrderButton_Click(object sender, EventArgs e)
        {
            var amount = Int32.Parse(amoutEditText.Text);

            var dialog = new AlertDialog.Builder(this);
            dialog.SetMessage("Confirmation");
            dialog.SetMessage("Your hot dog has benn added to you cart!!");
            dialog.Show();
        }
    }
}