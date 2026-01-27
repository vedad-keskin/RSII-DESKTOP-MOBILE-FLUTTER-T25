
import 'package:ecommerce_mobile/layouts/master_screen.dart';
import 'package:ecommerce_mobile/model/cart_provider.dart';
import 'package:ecommerce_mobile/model/favoriti.dart';
import 'package:ecommerce_mobile/providers/favoriti_provider.dart';
import 'package:ecommerce_mobile/providers/product_provider.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

class FrmFavoritiIB180079 extends StatefulWidget {
  const FrmFavoritiIB180079({super.key});

  @override
  State<FrmFavoritiIB180079> createState() => _FrmFavoritiIB180079State();
}

class _FrmFavoritiIB180079State extends State<FrmFavoritiIB180079> {
  late FavoritiProvider favoritiProvider;
  late CartProvider cartProvider;
  late ProductProvider productProvider;

  DateTime? dateFrom;
  DateTime? dateTo;


  List<FavoritiIB180079>? favoriti;

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
    favoritiProvider = context.read<FavoritiProvider>();
    cartProvider = context.read<CartProvider>();
    productProvider = context.read<ProductProvider>();
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreen(
      title: "Favoriti List",
      child: Center(
        child: Column(
          children: [
            _buildSearch(),
            _buildResultView()
          ],
        ),
      ),
    );
  }

  Widget _buildSearch() {
    return Padding(
        padding: EdgeInsets.all(10),
        child: Row(
          children: [
            Expanded(
              child: 
              TextButton(onPressed: () async  {

                var date = await showDatePicker(context: context,
                //  initialDate: dateFrom,
                 firstDate: DateTime(2000),
                 lastDate: DateTime(2100));

                 if(date != null){

                  setState(() {

                    dateFrom = date;

                  });


                 }
              
              }
              
              , child: 
              
               Text(dateFrom == null ? "Date From" : "${dateFrom!.day}.${dateFrom!.month}.${dateFrom!.year}")

              
              )

        
            ),
            SizedBox(width: 10),
            Expanded(
              child:      TextButton(onPressed: () async  {

                var date = await showDatePicker(context: context,
                //  initialDate: dateFrom,
                 firstDate: DateTime(2000),
                 lastDate: DateTime(2100));

                 if(date != null){

                  setState(() {

                    dateTo = date;

                  });


                 }
              
              }
              
              , child: 
              
               Text(dateTo == null ? "Date To" : "${dateTo!.day}.${dateTo!.month}.${dateTo!.year}")

              
              )
            ),
             Expanded(
              child:      TextButton(onPressed: () async  {

                

              

                  setState(() {

                    dateTo = null;
                    dateFrom = null;

                  });


                
              
              }
              
              , child: 
              
               Text("Reset Date")

              
              )
            ),
            SizedBox(width: 10),
            ElevatedButton(
              onPressed: () async {

                var filter = {
                  "dateFrom": dateFrom,
                  "dateTo": dateTo,
                };

                var favoriti = await favoritiProvider.getAsync(filter: filter);

                this.favoriti = favoriti;
                setState(() {});
              },
              child: Text("Search"),
            ),
            SizedBox(width: 10),
            // ElevatedButton(
            //   onPressed: () {
            //     Navigator.push(context, MaterialPageRoute(builder: (context) => ProductDetailsScreen(product: null)));
            //   },
            //   child: Text("New"),
            // )
          ],
        ));
  }
  

  Widget _buildResultView() {
    return Expanded(child: Container(
      width: double.infinity,
      child: SingleChildScrollView(
        child: DataTable(
        columns: [
          DataColumn(label: Text("ID")),
          DataColumn(label: Text("User Full Name")),
          DataColumn(label: Text("Product Name")), 
          DataColumn(label: Text("Created At")),
          DataColumn(label: Text("Actions")),

        ],
        rows: favoriti?.map((e) => DataRow(
          // onSelectChanged: (value) {
          //   Navigator.push(context, MaterialPageRoute(builder: (context) => ProductDetailsScreen(product: e)));
          // },
          cells: [
            DataCell(Text(e.id.toString())),
            DataCell(Text(e.userFullName)),
            DataCell(Text(e.productName)),
            DataCell(Text(e.createdAt.toString())),
            DataCell(
             IconButton(onPressed: () async {

              var products = await productProvider.get();

              var selectedProduct = products.items?.where((x) => x.name ==  e.productName).firstOrNull;

              if(selectedProduct != null){

                cartProvider.addToCart(selectedProduct);

              }
             



           }, icon: Icon(Icons.shopping_cart))



            )
          ])).toList() ?? [],
      ),
      ),
    ));
  }

}
