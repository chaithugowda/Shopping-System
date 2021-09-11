using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FillPage();
    }

    private void FillPage()
    {
        //Get a list of all products in DB
        ProductModel productModel = new ProductModel();
        List<Product> products = productModel.GetAllProducts();
        //Make sure Products Exist in the DataBase
        if (products != null)
        {

            //Create a new Panel with an ImageButton and 2 labels for each Product
            foreach (Product product in products)
            {
                Panel productPanel = new Panel();
                ImageButton imageButton = new ImageButton();
                Label lblName = new Label();
                Label lblPrice = new Label();

                //set childControls' Properties 
                imageButton.ImageUrl = "~/images/Products/" + product.Image;
                imageButton.CssClass = "productImage";
                imageButton.PostBackUrl = "~/pages/Product.aspx?id=" + product.ID;

                lblName.Text = product.Name;
                lblName.CssClass = "productPrice";

                lblPrice.Text = "₹ " + product.Price;
                lblPrice.CssClass = "productPrice";


                //ADD Child controls to panel
                productPanel.Controls.Add(imageButton);
                productPanel.Controls.Add(new Literal { Text = "<br />" });
                productPanel.Controls.Add(lblName);
                productPanel.Controls.Add(new Literal { Text = "<br />" });
                productPanel.Controls.Add(lblPrice);

                //add dynamic Panels to static Parent panel 
                PnlProducts.Controls.Add(productPanel);

            }
        }

        else
        {
            //No products Found 
            PnlProducts.Controls.Add(new Literal { Text = "No Product found" });
        }
    }
}



