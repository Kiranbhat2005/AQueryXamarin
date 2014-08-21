using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Com.Androidquery.Util;

namespace ListViewLazyLoadingImages
{
    [Activity(Label = "ListViewLazyLoadingImages", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Button btnClearCache = FindViewById<Button>(Resource.Id.btnClearCache);
            btnClearCache.Click += btnClearCache_Click;


            List<Product> products = GetProducts();

            ListView lvLazy = FindViewById<ListView>(Resource.Id.lvLazy);
            lvLazy.Adapter = new LazyLoadAdapter(this, products);
        }

        void btnClearCache_Click(object sender, EventArgs e)
        {
            // clear the Cache.
            AQUtility.CleanCacheAsync(this, 0, 0);
            Com.Androidquery.Callback.BitmapAjaxCallback.ClearCache();
        }

        // Returns a list of products which contains images Urls for testing purpose.
        private List<Product> GetProducts()
        {
            return new List<Product>(){ 
                new Product(){Id=1,Name="Chocolate",ImageUrl="http://androidexample.com/media/webservice/LazyListView_images/image0.png"},
                new Product(){Id=2,Name="Pizza",ImageUrl="http://androidexample.com/media/webservice/LazyListView_images/image1.png"},
                new Product(){Id=3,Name="Coffee",ImageUrl="http://androidexample.com/media/webservice/LazyListView_images/image2.png"},
                new Product(){Id=4,Name="Butter",ImageUrl="http://androidexample.com/media/webservice/LazyListView_images/image3.png"},
                new Product(){Id=5,Name="Milk",ImageUrl="http://androidexample.com/media/webservice/LazyListView_images/image4.png"},
                new Product(){Id=6,Name="Mango",ImageUrl="http://androidexample.com/media/webservice/LazyListView_images/image5.png"},
                new Product(){Id=7,Name="Cheese",ImageUrl="http://androidexample.com/media/webservice/LazyListView_images/image6.png"},
                new Product(){Id=8,Name="Wheat",ImageUrl="http://androidexample.com/media/webservice/LazyListView_images/image7.png"},
                new Product(){Id=9,Name="Sugar",ImageUrl="http://androidexample.com/media/webservice/LazyListView_images/image8.png"},
                new Product(){Id=10,Name="Ginger Tea",ImageUrl="http://androidexample.com/media/webservice/LazyListView_images/image9.png"},
                new Product(){Id=11,Name="Olive oil",ImageUrl="http://lh6.ggpht.com/-cQttOeY2-nQ/Th_ca6qTudI/AAAAAAAAAAA/FXtIo5ovK-o/s144-c/IMG_0682_cp.jpg"},
                new Product(){Id=12,Name="Rice",ImageUrl="http://lh3.ggpht.com/_loGyjar4MMI/S-InZA8YsZI/AAAAAAAADH8/csssVxalPcc/s144-c/Seahorse.jpg"},
                new Product(){Id=13,Name="Blueberry muffins",ImageUrl="http://lh4.ggpht.com/_DJGvVWd7IEc/TBpRsGjdAyI/AAAAAAAAFNw/rdvyRDgUD8A/s144-c/Free.jpg"},
                new Product(){Id=14,Name="Cake",ImageUrl="http://lh5.ggpht.com/_Z6tbBnE-swM/TB0CryLkiLI/AAAAAAAAVSo/n6B78hsDUz4/s144-c/_DSC3454.jpg"},
                new Product(){Id=14,Name="Strawberry ice crem",ImageUrl="http://lh3.ggpht.com/_GEnSvSHk4iE/TDSfmyCfn0I/AAAAAAAAF8Y/cqmhEoxbwys/s144-c/_MG_3675.jpg"},
                new Product(){Id=15,Name="Mango yogurt",ImageUrl="http://lh6.ggpht.com/_Nsxc889y6hY/TBp7jfx-cgI/AAAAAAAAHAg/Rr7jX44r2Gc/s144-c/IMGP9775a.jpg"},
                new Product(){Id=16,Name="Chilly sauce",ImageUrl="http://lh3.ggpht.com/_lLj6go_T1CQ/TCD8PW09KBI/AAAAAAAAQdc/AqmOJ7eg5ig/s144-c/Juvenile%20Gannet%20despute.jpg"},
                new Product(){Id=17,Name="Groundnut butter",ImageUrl="http://lh6.ggpht.com/_ZN5zQnkI67I/TCFFZaJHDnI/AAAAAAAABVk/YoUbDQHJRdo/s144-c/P9250508.JPG"},
                new Product(){Id=18,Name="Milk chocolate",ImageUrl="http://lh4.ggpht.com/_XjNwVI0kmW8/TCOwNtzGheI/AAAAAAAAC84/SxFJhG7Scgo/s144-c/0014.jpg"},
                new Product(){Id=19,Name="Tomato sauce",ImageUrl="http://lh6.ggpht.com/_loGyjar4MMI/S-InVNkTR_I/AAAAAAAADJY/Fb5ifFNGD70/s144-c/Moving%20Rock.jpg"},
                new Product(){Id=20,Name="Soya",ImageUrl="http://lh6.ggpht.com/_iGI-XCxGLew/S-iYQWBEG-I/AAAAAAAACB8/JuFti4elptE/s144-c/norvig-polar-bear.jpg"},
                new Product(){Id=21,Name="Baked beans",ImageUrl="http://lh4.ggpht.com/_yy6KdedPYp4/SB5rpK3Zv0I/AAAAAAAAOM8/mokl_yo2c9E/s144-c/Point%20Reyes%20road%20.jpg"},
                new Product(){Id=22,Name="Mobile",ImageUrl="http://lh3.ggpht.com/_QFsB_q7HFlo/TCItc19Jw3I/AAAAAAAAFs4/nPfiz5VGENk/s144-c/4551649039_852be0a952_o.jpg"}

            };
        }
    }
}

