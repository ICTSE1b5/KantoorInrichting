﻿// created by: Robin
// on: 04-01-2016

#region

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using KantoorInrichting.Controllers.Placement.Handler;
using KantoorInrichting.Models.Placement;
using KantoorInrichting.Models.Product;

#endregion

namespace KantoorInrichting.Controllers.Placement
{
    public class ProductGridUtility
    {
        public Rectangle GetProductRectangle(PlacedProduct product, float width, float height, float size)
        {
            Rectangle rectangle;
            if (product.Product.Size.IsEmpty)
            {
                // this is a product that came from the algorithm
                rectangle = new Rectangle
                {
                    Height = (int) (product.Product.Height/size*height),
                    Width = (int) (product.Product.Width/size*width),
                    X = (int) (product.Location.X/size*width),
                    Y = (int) (product.Location.Y/size*height)
                };
            }
            else
            {
                rectangle = new Rectangle
                {
                    Height = (int) (product.Product.Size.Height/size*height),
                    Width = (int) (product.Product.Size.Width/size*width),
                    X = (int) (product.Location.X/size*width),
                    Y = (int) (product.Location.Y/size*height)
                };
            }
            return rectangle;
        }

        /// <summary>
        /// Selects the Brush where the type matches from the Dictionary kept in the Legend.
        /// </summary>
        /// <param name="product"></param>
        /// <param name="dict"></param>
        /// <returns></returns>
        public SolidBrush SelectBrush(PlacedProduct product, Dictionary<string, SolidBrush> dict)
        {
            SolidBrush brush;
            try
            {
                CategoryModel Currentcat = product.Product.ProductCategory;

                if (Currentcat.IsSubcategoryFrom > -1 || Currentcat.IsSubcategoryFrom == null) // is a subcategory
                {
                    // gets the main category id
                    int MainId = (int) Currentcat.IsSubcategoryFrom;

                    // linq select category with the current id
                    var selectedcategory2 = CategoryModel.List
                        .Where(c => c.CatId == MainId)
                        .Select(c => c)
                        .ToList();

                    CategoryModel Main = selectedcategory2[0];

                    // gets the value (color) from the Main productcategory
                    brush = new SolidBrush(Main.Colour);
                }
                else // is a maincategory
                {
                    // give the color from the main category
                    brush = dict.Single(pair => pair.Key.Equals(product.Product.Category)).Value;
                }
            }
            catch (InvalidOperationException e)
            {
                // This means that the type is not found in the dictionary, and so I will set the Brush to Black
                brush = new SolidBrush(Color.Gray);
            }
            return brush;
        }

        public PlacedProduct GetProductFromField(Point point, List<PlacedProduct> products, float width, float height,
            float size)
        {
            PlacedProduct result = null;
            PointF realPoint = TransformToRealWorld(point, width, height, size);
            foreach (PlacedProduct current in products)
            {
                PointF currentLocation = current.Location;

                bool xOnPoint = (currentLocation.X <= realPoint.X) &&
                                (currentLocation.X + current.Product.Size.Width >= realPoint.X),
                    yOnPoint = (currentLocation.Y <= realPoint.Y) &&
                               currentLocation.Y + current.Product.Size.Height >= realPoint.Y;

                if (xOnPoint && yOnPoint)
                {
                    result = current;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// Returns a Point with the X and Y in real world measurements.
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public PointF TransformToRealWorld(Point point, float width, float height, float size)
        {
            float resultX = point.X/width*size,
                resultY = point.Y/height*size;
            return new PointF(resultX, resultY);
        }

        public void MoveProduct(ICollisionHandler<PlacedProduct> handler, PlacedProduct selectedProduct,
            List<PlacedProduct> placedProducts, int boundWidth, int boundHeight,
            float realWidth, float realHeight, float x, float y, bool real)
        {
            float selectedWidth = selectedProduct.Product.Size.Width,
                selectedHeight = selectedProduct.Product.Size.Height;

            float newX = (real) ? x : x/(float) boundWidth*realWidth
                         - selectedWidth/2,
                newY = (real) ? y : y/(float) boundHeight*realHeight
                       - selectedHeight/2;
            

            if (newX <= 0)
                newX = 0;
            if (newX + selectedWidth/2 >= realWidth - selectedWidth/2)
                newX = realWidth - selectedWidth;
            if (newY <= 0)
                newY = 0;
            if (newY + selectedHeight/2 >= realHeight - selectedHeight/2)
                newY = realHeight - selectedHeight;

            PointF newLocation = new PointF(newX, newY);
            selectedProduct.Location = !handler.Collision(selectedProduct, placedProducts)
                ? newLocation
                : selectedProduct.OriginalLocation;
        }

        public void MoveProduct(PlacedProduct selectedProduct, List<PlacedProduct> placedProducts, Vector deltaVector, int panelWidth, int panelHeight)
        {
            //A variable to keep track of collision
            bool collision = false;
            

            //The new location that the product is going towards
            Point newLocationPoint = new Point(
                (int)(selectedProduct.Location.X + deltaVector.X),
                (int)(selectedProduct.Location.Y + deltaVector.Y)   );

            


            //Checkes the borders
            foreach (Polygon wall in selectedProduct.PolyBorder(panelWidth, panelHeight))
            {
                PolygonCollisionController.PolygonCollisionResult result =
                    PolygonCollisionController.PolygonCollision(selectedProduct.Poly, wall, deltaVector);

                if (result.WillIntersect)
                {
                    collision = true;
                    break;
                }
            }


            //Loops through each item and determines if it collides with any of them
            foreach (PlacedProduct collisionTarget in placedProducts)
            {
                if (collision)
                { break; }
                if (selectedProduct.Product.Collidable == false) //If the selected product is not collidable. For example an 'Energy Socket'. Break out the loop and place it.
                { break; }
                if (collisionTarget.Product.Collidable == false) //If the target is not collidable. For example an 'Energy Socket'. Skip this loop and go to the next target.
                { continue; }

                PolygonCollisionController.PolygonCollisionResult result =
                    PolygonCollisionController.PolygonCollision(selectedProduct.Poly, collisionTarget.Poly, deltaVector);

                if (result.WillIntersect)
                {
                    collision = true;
                    break;
                }
            }

            //Failsafe check at the end
            if (!collision)
            { /*selectedProduct.MoveTo(newLocationPoint); */}
            else
            {
                MessageBox.Show("Fail");
            }
            MessageBox.Show(newLocationPoint.ToString());

        }
    }
}