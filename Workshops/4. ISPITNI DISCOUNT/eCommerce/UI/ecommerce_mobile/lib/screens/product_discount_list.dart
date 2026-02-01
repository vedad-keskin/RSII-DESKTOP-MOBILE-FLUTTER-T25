
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

  TextEditingController codeController = TextEditingController();
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
            _buildTotalDiscount(),
          ],
        ),
      ),
    );
  }

  double get _totalDiscountAmount {
    if (productDiscounts?.items == null) return 0;
    //return productDiscounts!.items!.fold(0.0, (sum, e) => sum + (e.productPrice - e.newPrice));

    double totalDiscountAmount = 0;

    for (var item in productDiscounts!.items!) {
      totalDiscountAmount += item.productPrice - item.newPrice;
    }
    return totalDiscountAmount;


  }

  Widget _buildTotalDiscount() {
    return Padding(
      padding: EdgeInsets.all(16),
      child: Text("Total discounted: ${_totalDiscountAmount.toStringAsFixed(2)}"),
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
                onChanged: (value) async {
                 
                var filter = {
                  "productName": searchController.text,
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
                  "productName": searchController.text,
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
          DataColumn(label: Text("")),
        ],
        rows: productDiscounts?.items?.map((e) => DataRow(
          onSelectChanged: (value) {
            Navigator.push(context, MaterialPageRoute(builder: (context) => ProductDiscountAdd(productDiscount: e)));
          },
          cells: [
            DataCell(    Container(
              height: 80,
              width: 80,
              child: e.assets.firstOrNull == null 
                ? Placeholder() 
                : imageFromString(e.assets.first.base64Content),
            ),),
            DataCell(Text(e.productName)),
            DataCell(Text(e.productPrice.toString())),
            DataCell(Text(e.discount.toString())),
            DataCell(Text(e.newPrice.toStringAsFixed(2))),
            DataCell(Text(DateFormat("dd.MM.yyyy").format(e.dateFrom ?? DateTime.now()))),
            DataCell(Text(DateFormat("dd.MM.yyyy").format(e.dateTo ?? DateTime.now()))),
            DataCell(IconButton(
              icon: Icon(Icons.delete), 
              onPressed: () async {
                await productDiscountProvider.delete(e.id);
                loadData();
              },
            )),
          ],
        )).toList() ?? [],
      ),
      ),
    ));
  }

}
