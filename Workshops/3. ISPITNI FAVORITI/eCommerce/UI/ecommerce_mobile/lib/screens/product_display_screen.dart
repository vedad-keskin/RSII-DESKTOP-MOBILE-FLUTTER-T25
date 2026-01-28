import 'package:ecommerce_mobile/layouts/master_screen.dart';
import 'package:ecommerce_mobile/model/product.dart';
import 'package:ecommerce_mobile/providers/favoriti_provider.dart';
import 'package:ecommerce_mobile/providers/utils.dart';
import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';
import 'package:provider/provider.dart';


class ProductDisplayScreen extends StatefulWidget {
  Product? product;
  ProductDisplayScreen({super.key, this.product});

  @override
  State<ProductDisplayScreen> createState() => _ProductDisplayScreenState();
}

class _ProductDisplayScreenState extends State<ProductDisplayScreen> {

  late FavoritiProvider favoritiProvider;


  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
    favoritiProvider = context.read<FavoritiProvider>();
  }

  
  Widget build(BuildContext context) {
    return MasterScreen(
      title: "Product Display",
      child: Padding(
        padding: EdgeInsetsGeometry.all(16),
        child: 
        Column(
             crossAxisAlignment: CrossAxisAlignment.center,
            children: [

            Container(
              width: 200,
              height: 200,
              child: imageFromString(widget.product!.assets.first.base64Content),
            ),
            SizedBox(height: 10),
            Text("Name: ${widget.product?.name ?? "N/A"}", style: TextStyle(fontSize: 20, fontWeight: FontWeight.bold)),
            SizedBox(height: 10),
            Text( "Price: ${formatNumber( widget.product?.price)}"  , style: TextStyle(fontSize: 20, fontWeight: FontWeight.bold)),
                        SizedBox(height: 10),

            Row(
              mainAxisAlignment: MainAxisAlignment.center,

               children: [
              ElevatedButton(onPressed: () async {
              // TODO Add to F
            
              
              await favoritiProvider.addFavouritesAsync(FavoritiProvider.userId, widget.product!.id);


              }, child: Text("Add to Favorites")),
              SizedBox(width: 20),

              ElevatedButton(onPressed: () async {
              // TODO Remove from F

              await favoritiProvider.removeFavouritesAsync(FavoritiProvider.userId, widget.product!.id);


              }, child: Text("Remove from Favorites"))


               ],

            )

            ],
      ),
      ),
    );
  }



}
