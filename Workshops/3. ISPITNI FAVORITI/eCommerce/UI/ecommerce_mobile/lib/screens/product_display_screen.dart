import 'package:ecommerce_mobile/layouts/master_screen.dart';
import 'package:ecommerce_mobile/model/product.dart';
import 'package:ecommerce_mobile/providers/utils.dart';
import 'package:flutter/material.dart';

class ProductDisplayScreen extends StatefulWidget {
  final Product product;
  
  const ProductDisplayScreen({super.key, required this.product});

  @override
  State<ProductDisplayScreen> createState() => _ProductDisplayScreenState();
}

class _ProductDisplayScreenState extends State<ProductDisplayScreen> {
  @override
  Widget build(BuildContext context) {
    return MasterScreen(
      title: "Product Details",
      child: Padding(
        padding: EdgeInsets.all(16),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.center,
          children: [
            if (widget.product.assets.isNotEmpty)
              Container(
                height: 200,
                width: 200,
                child: imageFromString(widget.product.assets.first.base64Content),
              )
            else
              Container(
                height: 200,
                width: 200,
                color: Colors.grey[300],
                child: Icon(Icons.image, size: 100),
              ),
            SizedBox(height: 20),
            Text(widget.product.name, style: TextStyle(fontSize: 24, fontWeight: FontWeight.bold)),
            SizedBox(height: 10),
            Text("Price: ${formatNumber(widget.product.price)}", style: TextStyle(fontSize: 20, fontWeight: FontWeight.bold)),
            SizedBox(height: 30),
            Row(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                ElevatedButton(
                  onPressed: () {
                    // TODO: Implement add to favourites
                  },
                  child: Text("Add to Favourites"),
                ),
                SizedBox(width: 10),
                ElevatedButton(
                  onPressed: () {
                    // TODO: Implement remove from favourites
                  },
                  child: Text("Remove from Favourites"),
                ),
              ],
            ),
          ],
        ),
      ),
    );
  }
}