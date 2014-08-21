using Android.App;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using Com.Androidquery;
using Com.Androidquery.Callback;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListViewLazyLoadingImages
{
    public class LazyLoadAdapter : BaseAdapter
    {
        Activity _activity;
        List<Product> _products;

        public LazyLoadAdapter(Activity activity, List<Product> products)
        {
            _activity = activity;
            _products = products;
        }

        public override int Count
        {
            get { return _products.Count; }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Android.Views.View GetView(int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
        {
            if (convertView == null)
            {
                convertView = _activity.LayoutInflater.Inflate(Resource.Layout.list_item, parent, false);
            }

            Product product = _products[position];

            AQuery aq = new AQuery(convertView);

            TextView txtProductName = convertView.FindViewById<TextView>(Resource.Id.txtProductName);
            txtProductName.Text = product.Name;

            Bitmap imgLoading = aq.GetCachedImage(Resource.Drawable.img_loading);

            if (aq.ShouldDelay(position, convertView, parent, product.ImageUrl))
            {
                ((AQuery)aq.Id(Resource.Id.imgProduct)).Image(imgLoading, 0.75f);
            }
            else
            {
                ((AQuery)aq.Id(Resource.Id.imgProduct)).Image(product.ImageUrl, true, true, 0, 0, imgLoading, 0, 0.75f);
            }

            return convertView;
        }
    }
}
