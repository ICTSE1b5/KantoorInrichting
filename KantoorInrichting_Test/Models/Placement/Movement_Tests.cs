﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using KantoorInrichting.Models.Product;

namespace KantoorInrichting_Test.Models.Placement
{
    [TestClass]
    public class Movement_Tests
    {
        [TestMethod]
        public void move_SingleMoveHorizontal()
        {
            //Move X+10, Y+0

            //Make
            PointF point = new PointF(200, 200);
            ProductModel product = new ProductModel(10, 10, 50);
            PlacedProduct placedP = new PlacedProduct(product, point);

            int move_x = 10;
            int move_y = 0;

            PointF[] pointCorner = new PointF[4];
            pointCorner[0] = new PointF(point.X - (product.Width / 2) + move_x, point.Y - (product.Length / 2) + move_y);   //{205 ; 195}
            pointCorner[1] = new PointF(point.X + (product.Width / 2) + move_x, point.Y - (product.Length / 2) + move_y);   //{215 ; 195}
            pointCorner[2] = new PointF(point.X + (product.Width / 2) + move_x, point.Y + (product.Length / 2) + move_y);   //{215 ; 205}
            pointCorner[3] = new PointF(point.X - (product.Width / 2) + move_x, point.Y + (product.Length / 2) + move_y);   //{205 ; 205}




            //Do
            placedP.GridSpace = 10;
            placedP.Move(true);
            point.X += move_x;
            point.Y += move_y;

            
            //Look
            Assert.AreEqual(point.X, placedP.Location.X, 0.1, "The horizontal location of the product is different!");
            Assert.AreEqual(point.Y, placedP.Location.Y, 0.1, "The vertical location of the product is different!");

            for (int index = 0; index < pointCorner.Length; index++)
            {
                Assert.AreEqual(pointCorner[index].ToString(), placedP.CornerPoints[index].ToString(), true, "Corner #" + index + " is in the wrong spot!");
            }
        }

        [TestMethod]
        public void move_SingleMoveVertical()
        {
            //Move X+0, Y+10

            //Make
            PointF point = new PointF(200, 200);
            ProductModel product = new ProductModel(10, 10, 50);
            PlacedProduct placedP = new PlacedProduct(product, point);

            int move_x = 0;
            int move_y = 10;

            PointF[] pointCorner = new PointF[4];
            pointCorner[0] = new PointF(point.X - (product.Width / 2) + move_x, point.Y - (product.Length / 2) + move_y);   //{195 ; 205}
            pointCorner[1] = new PointF(point.X + (product.Width / 2) + move_x, point.Y - (product.Length / 2) + move_y);   //{205 ; 205}
            pointCorner[2] = new PointF(point.X + (product.Width / 2) + move_x, point.Y + (product.Length / 2) + move_y);   //{205 ; 215}
            pointCorner[3] = new PointF(point.X - (product.Width / 2) + move_x, point.Y + (product.Length / 2) + move_y);   //{195 ; 215}




            //Do
            placedP.GridSpace = 10;
            placedP.Move(false);
            point.X += move_x;
            point.Y += move_y;


            //Look
            Assert.AreEqual(point.X, placedP.Location.X, 0.1, "The horizontal location of the product is different!");
            Assert.AreEqual(point.Y, placedP.Location.Y, 0.1, "The vertical location of the product is different!");

            for (int index = 0; index < pointCorner.Length; index++)
            {
                Assert.AreEqual(pointCorner[index].ToString(), placedP.CornerPoints[index].ToString(), true, "Corner #" + index + " is in the wrong spot!");
            }
        }

        [TestMethod]
        public void move_MultipleMove()
        {
            //Move X+10, Y+0
            //Move X+0, Y+10
            //Move X+10, Y+0
            
            //Make
            PointF point = new PointF(200, 200);
            ProductModel product = new ProductModel(10, 10, 50);
            PlacedProduct placedP = new PlacedProduct(product, point);

            int move_x = 20;    //The total movement
            int move_y = 10;

            PointF[] pointCorner = new PointF[4];
            pointCorner[0] = new PointF(point.X - (product.Width / 2) + move_x, point.Y - (product.Length / 2) + move_y);   //{195 ; 205}
            pointCorner[1] = new PointF(point.X + (product.Width / 2) + move_x, point.Y - (product.Length / 2) + move_y);   //{205 ; 205}
            pointCorner[2] = new PointF(point.X + (product.Width / 2) + move_x, point.Y + (product.Length / 2) + move_y);   //{205 ; 215}
            pointCorner[3] = new PointF(point.X - (product.Width / 2) + move_x, point.Y + (product.Length / 2) + move_y);   //{195 ; 215}




            //Do
            placedP.GridSpace = 10;
            placedP.Move(true);
            placedP.Move(false);
            placedP.Move(true);
            point.X += move_x;
            point.Y += move_y;


            //Look
            Assert.AreEqual(point.X, placedP.Location.X, 0.1, "The horizontal location of the product is different!");
            Assert.AreEqual(point.Y, placedP.Location.Y, 0.1, "The vertical location of the product is different!");

            for (int index = 0; index < pointCorner.Length; index++)
            {
                Assert.AreEqual(pointCorner[index].ToString(), placedP.CornerPoints[index].ToString(), true, "Corner #" + index + " is in the wrong spot!");
            }
        }

        [TestMethod]
        public void move_SingleBackwardMoveHorizontal()
        {
            //Move X-10, Y+0

            //Make
            PointF point = new PointF(200, 200);
            ProductModel product = new ProductModel(10, 10, 50);
            PlacedProduct placedP = new PlacedProduct(product, point);

            int move_x = -10;
            int move_y = 0;

            PointF[] pointCorner = new PointF[4];
            pointCorner[0] = new PointF(point.X - (product.Width / 2) + move_x, point.Y - (product.Length / 2) + move_y);   //{195 ; 205}
            pointCorner[1] = new PointF(point.X + (product.Width / 2) + move_x, point.Y - (product.Length / 2) + move_y);   //{205 ; 205}
            pointCorner[2] = new PointF(point.X + (product.Width / 2) + move_x, point.Y + (product.Length / 2) + move_y);   //{205 ; 215}
            pointCorner[3] = new PointF(point.X - (product.Width / 2) + move_x, point.Y + (product.Length / 2) + move_y);   //{195 ; 215}




            //Do
            placedP.GridSpace = -10;
            placedP.Move(true);
            point.X += move_x;
            point.Y += move_y;


            //Look
            Assert.AreEqual(point.X, placedP.Location.X, 0.1, "The horizontal location of the product is different!");
            Assert.AreEqual(point.Y, placedP.Location.Y, 0.1, "The vertical location of the product is different!");

            for (int index = 0; index < pointCorner.Length; index++)
            {
                Assert.AreEqual(pointCorner[index].ToString(), placedP.CornerPoints[index].ToString(), true, "Corner #" + index + " is in the wrong spot!");
            }
        }

        [TestMethod]
        public void move_SingleBackwardMoveVertical()
        {
            //Move X+0, Y-10

            //Make
            PointF point = new PointF(200, 200);
            ProductModel product = new ProductModel(10, 10, 50);
            PlacedProduct placedP = new PlacedProduct(product, point);

            int move_x = 0;
            int move_y = -10;

            PointF[] pointCorner = new PointF[4];
            pointCorner[0] = new PointF(point.X - (product.Width / 2) + move_x, point.Y - (product.Length / 2) + move_y);   //{195 ; 205}
            pointCorner[1] = new PointF(point.X + (product.Width / 2) + move_x, point.Y - (product.Length / 2) + move_y);   //{205 ; 205}
            pointCorner[2] = new PointF(point.X + (product.Width / 2) + move_x, point.Y + (product.Length / 2) + move_y);   //{205 ; 215}
            pointCorner[3] = new PointF(point.X - (product.Width / 2) + move_x, point.Y + (product.Length / 2) + move_y);   //{195 ; 215}




            //Do
            placedP.GridSpace = -10;
            placedP.Move(false);
            point.X += move_x;
            point.Y += move_y;


            //Look
            Assert.AreEqual(point.X, placedP.Location.X, 0.1, "The horizontal location of the product is different!");
            Assert.AreEqual(point.Y, placedP.Location.Y, 0.1, "The vertical location of the product is different!");

            for (int index = 0; index < pointCorner.Length; index++)
            {
                Assert.AreEqual(pointCorner[index].ToString(), placedP.CornerPoints[index].ToString(), true, "Corner #" + index + " is in the wrong spot!");
            }
        }

        [TestMethod]
        public void move_MultipleBackwardMove()
        {
            //Move X-10, Y+0
            //Move X+0, Y-10
            //Move X-10, Y+0

            //Make
            PointF point = new PointF(200, 200);
            ProductModel product = new ProductModel(10, 10, 50);
            PlacedProduct placedP = new PlacedProduct(product, point);

            int move_x = -20;    //The total movement
            int move_y = -10;

            PointF[] pointCorner = new PointF[4];
            pointCorner[0] = new PointF(point.X - (product.Width / 2) + move_x, point.Y - (product.Length / 2) + move_y);   //{195 ; 205}
            pointCorner[1] = new PointF(point.X + (product.Width / 2) + move_x, point.Y - (product.Length / 2) + move_y);   //{205 ; 205}
            pointCorner[2] = new PointF(point.X + (product.Width / 2) + move_x, point.Y + (product.Length / 2) + move_y);   //{205 ; 215}
            pointCorner[3] = new PointF(point.X - (product.Width / 2) + move_x, point.Y + (product.Length / 2) + move_y);   //{195 ; 215}




            //Do
            placedP.GridSpace = -10;
            placedP.Move(true);
            placedP.Move(false);
            placedP.Move(true);
            point.X += move_x;
            point.Y += move_y;


            //Look
            Assert.AreEqual(point.X, placedP.Location.X, 0.1, "The horizontal location of the product is different!");
            Assert.AreEqual(point.Y, placedP.Location.Y, 0.1, "The vertical location of the product is different!");

            for (int index = 0; index < pointCorner.Length; index++)
            {
                Assert.AreEqual(pointCorner[index].ToString(), placedP.CornerPoints[index].ToString(), true, "Corner #" + index + " is in the wrong spot!");
            }
        }

        [TestMethod]
        public void move_MultipleMixedMove1()
        {
            //Move X+10, Y+0
            //Move X+0, Y+10
            //Move X-20, Y+0
            //Move X-20, Y+0
            //Move X+0, Y-15

            //Make
            PointF point = new PointF(200, 200);
            ProductModel product = new ProductModel(10, 10, 50);
            PlacedProduct placedP = new PlacedProduct(product, point);

            int move_x = -30;    //The total movement
            int move_y = -5;

            PointF[] pointCorner = new PointF[4];
            pointCorner[0] = new PointF(point.X - (product.Width / 2) + move_x, point.Y - (product.Length / 2) + move_y);   //{195 ; 205}
            pointCorner[1] = new PointF(point.X + (product.Width / 2) + move_x, point.Y - (product.Length / 2) + move_y);   //{205 ; 205}
            pointCorner[2] = new PointF(point.X + (product.Width / 2) + move_x, point.Y + (product.Length / 2) + move_y);   //{205 ; 215}
            pointCorner[3] = new PointF(point.X - (product.Width / 2) + move_x, point.Y + (product.Length / 2) + move_y);   //{195 ; 215}




            //Do
            placedP.GridSpace = 10;
            placedP.Move(true);
            placedP.Move(false);
            placedP.GridSpace = -20;
            placedP.Move(true);
            placedP.Move(true);
            placedP.GridSpace = -15;
            placedP.Move(false);
            point.X += move_x;
            point.Y += move_y;


            //Look
            Assert.AreEqual(point.X, placedP.Location.X, 0.1, "The horizontal location of the product is different!");
            Assert.AreEqual(point.Y, placedP.Location.Y, 0.1, "The vertical location of the product is different!");

            for (int index = 0; index < pointCorner.Length; index++)
            {
                Assert.AreEqual(pointCorner[index].ToString(), placedP.CornerPoints[index].ToString(), true, "Corner #" + index + " is in the wrong spot!");
            }
        }

        [TestMethod]
        public void move_MoveRotate()
        {
            //Move X+0, Y+15
            //Rotate

            //Make
            PointF point = new PointF(200, 200);
            ProductModel product = new ProductModel(10, 10, 50);
            PlacedProduct placedP = new PlacedProduct(product, point);

            int move_x = 0;
            int move_y = 15;

            PointF[] pointCorner = new PointF[4];
            pointCorner[0] = new PointF(point.X + (product.Width / 2) + move_x, point.Y - (product.Length / 2) + move_y);   //{205 ; 210}
            pointCorner[1] = new PointF(point.X + (product.Width / 2) + move_x, point.Y + (product.Length / 2) + move_y);   //{205 ; 220}
            pointCorner[2] = new PointF(point.X - (product.Width / 2) + move_x, point.Y + (product.Length / 2) + move_y);   //{195 ; 220}
            pointCorner[3] = new PointF(point.X - (product.Width / 2) + move_x, point.Y - (product.Length / 2) + move_y);   //{195 ; 210}




            //Do
            placedP.GridSpace = 15;
            placedP.Move(false);
            placedP.AddAngle(90);
            point.X += move_x;
            point.Y += move_y;


            //Look
            Assert.AreEqual(point.X, placedP.Location.X, 0.1, "The horizontal location of the product is different!");
            Assert.AreEqual(point.Y, placedP.Location.Y, 0.1, "The vertical location of the product is different!");

            for (int index = 0; index < pointCorner.Length; index++)
            {
                Assert.AreEqual(pointCorner[index].ToString(), placedP.CornerPoints[index].ToString(), true, "Corner #" + index + " is in the wrong spot!");
            }
        }

        [TestMethod]
        public void move_RotateMove()
        {
            //Rotate
            //Move X+0, Y+15

            //Make
            PointF point = new PointF(200, 200);
            ProductModel product = new ProductModel(10, 10, 50);
            PlacedProduct placedP = new PlacedProduct(product, point);

            int move_x = 0;
            int move_y = 15;

            PointF[] pointCorner = new PointF[4];
            pointCorner[0] = new PointF(point.X + (product.Width / 2) + move_x, point.Y - (product.Length / 2) + move_y);   //{205 ; 210}
            pointCorner[1] = new PointF(point.X + (product.Width / 2) + move_x, point.Y + (product.Length / 2) + move_y);   //{205 ; 220}
            pointCorner[2] = new PointF(point.X - (product.Width / 2) + move_x, point.Y + (product.Length / 2) + move_y);   //{195 ; 220}
            pointCorner[3] = new PointF(point.X - (product.Width / 2) + move_x, point.Y - (product.Length / 2) + move_y);   //{195 ; 210}


            //Do
            placedP.AddAngle(90);
            placedP.GridSpace = 15;
            placedP.Move(false);
            point.X += move_x;
            point.Y += move_y;


            //Look
            Assert.AreEqual(point.X, placedP.Location.X, 0.1, "The horizontal location of the product is different!");
            Assert.AreEqual(point.Y, placedP.Location.Y, 0.1, "The vertical location of the product is different!");

            for (int index = 0; index < pointCorner.Length; index++)
            {
                Assert.AreEqual(pointCorner[index].ToString(), placedP.CornerPoints[index].ToString(), true, "Corner #" + index + " is in the wrong spot!");
            }
        }
    }
}
