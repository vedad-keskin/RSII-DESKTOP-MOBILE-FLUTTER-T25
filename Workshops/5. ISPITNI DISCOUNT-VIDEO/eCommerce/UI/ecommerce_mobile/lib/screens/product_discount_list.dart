import 'package:ecommerce_mobile/layouts/master_screen.dart';
import 'package:ecommerce_mobile/model/product_discount.dart';
import 'package:ecommerce_mobile/model/search_result.dart';
import 'package:ecommerce_mobile/providers/product_discount_provider.dart';
import 'package:ecommerce_mobile/providers/utils.dart';
import 'package:ecommerce_mobile/screens/product_discount_add.dart';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';

class ProductDiscountList extends StatefulWidget {
  const ProductDiscountList({super.key});

  @override
  State<ProductDiscountList> createState() => _ProductDiscountListState();
}

class _ProductDiscountListState extends State<ProductDiscountList> {
  late ProductDiscountProvider productDiscountProvider;

  TextEditingController searchController = TextEditingController();

  SearchResult<ProductDiscount>? productDiscounts;

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
    productDiscountProvider = context.read<ProductDiscountProvider>();

    setState(() {
      loadData();
    });

  }

    void loadData() async {

     var productDiscounts = await productDiscountProvider.get();

     this.productDiscounts = productDiscounts;

      setState(() {});

    }

  @override
  Widget build(BuildContext context) {
    return MasterScreen(
      title: "Product Discount List",
      child: Center(
        child: Column(
          children: [
            _buildSearch(),
            _buildResultView(),
            _buildTotalDiscount()
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
              child: TextField(
                decoration: InputDecoration(
                  hintText: "Search",
                  border: OutlineInputBorder(),
                ),
                controller: searchController,
                onChanged: (value)  async {

                var filter = {
                  "ProductName": searchController.text,
                };
                debugPrint(filter.toString());

                var productDiscounts = await productDiscountProvider.get(filter: filter);

                this.productDiscounts = productDiscounts;
                setState(() {});

                },

              ),
            ),
            SizedBox(width: 10),
            ElevatedButton(
              onPressed: () async {
                var filter = {
                  "ProductName": searchController.text,
                };
                debugPrint(filter.toString());

                var productDiscounts = await productDiscountProvider.get(filter: filter);

                this.productDiscounts = productDiscounts;
                setState(() {});
              },
              child: Text("Search"),
            ),
            SizedBox(width: 10),
            ElevatedButton(
              onPressed: () {
                Navigator.push(context, MaterialPageRoute(builder: (context) => ProductDiscountAdd(productDiscount: null)));
              },
              child: Text("New"),
            )
          ],
        ));
  }
  

  Widget _buildResultView() {
    return Expanded(child: Container(
      width: double.infinity,
      child: SingleChildScrollView(
        child: DataTable(
        columns: [
          DataColumn(label: Text("Picture")),
          DataColumn(label: Text("Product")),
          DataColumn(label: Text("Price")), 
          DataColumn(label: Text("Discount")),
          DataColumn(label: Text("New Price")),
          DataColumn(label: Text("Date From")),
          DataColumn(label: Text("Date To")),
          DataColumn(label: Text("Actions")),

        ],
        rows: productDiscounts?.items?.map((e) => DataRow(
          onSelectChanged: (value) {
             Navigator.push(context, MaterialPageRoute(builder: (context) => ProductDiscountAdd(productDiscount: e)));
          },
          cells: [
            DataCell(

            Container(
              height: 50,
              width: 50,
              child: e.assets.firstOrNull == null 
                ? Placeholder() 
                : imageFromString(e.assets.first.base64Content),
            ),

            ),
            DataCell(Text(e.productName)),
            DataCell(Text(formatNumber(e.productPrice))),
            DataCell(Text(formatNumber(e.discount))),
            DataCell(Text(formatNumber(e.newPrice))),
            DataCell(Text(DateFormat("dd.MM.yyyy").format(e.dateFrom ?? DateTime.now()))),
            DataCell(Text(DateFormat("dd.MM.yyyy").format(e.dateTo ?? DateTime.now()))),
DataCell(

   IconButton(icon: const Icon(Icons.delete),
   onPressed: () async {

     await productDiscountProvider.delete(e.id);


        var filter = {
                  "ProductName": searchController.text,
                };

                var productDiscounts = await productDiscountProvider.get(filter: filter);

                this.productDiscounts = productDiscounts;
 setState(() {});
   },
   )

)
          ])).toList() ?? [],
      ),
      ),
    ));
  }
  
  Widget _buildTotalDiscount() {

     return Padding(
      padding: EdgeInsets.all(16),
     
        child: Text("Total Discounted: ${_totalDiscountedAmount.toStringAsFixed(2)}"),
          

     );
  }

  double get _totalDiscountedAmount {

    if(productDiscounts?.items == null){
      return 0;
    }

    double totalDiscountAmount = 0;

    for (var item in productDiscounts!.items!) {
      
        totalDiscountAmount = item.productPrice - item.newPrice;

    }


    return totalDiscountAmount;


  }
  


}
