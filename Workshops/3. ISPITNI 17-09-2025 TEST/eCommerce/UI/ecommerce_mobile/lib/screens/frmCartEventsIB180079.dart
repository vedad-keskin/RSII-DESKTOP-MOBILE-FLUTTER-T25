
import 'package:ecommerce_mobile/layouts/master_screen.dart';
import 'package:ecommerce_mobile/model/cart_event.dart';
import 'package:ecommerce_mobile/model/cart_event_provider.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';


class FrmCartEventsIB180079 extends StatefulWidget {
  const FrmCartEventsIB180079({super.key});

  @override
  State<FrmCartEventsIB180079> createState() => _FrmCartEventsIB180079State();
}

class _FrmCartEventsIB180079State extends State<FrmCartEventsIB180079> {
  late CartEventProvider cartEventProvider;

  TextEditingController codeController = TextEditingController();
  TextEditingController searchController = TextEditingController();

  List<CartEvent>? cartEvents;

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
    cartEventProvider = context.read<CartEventProvider>();
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreen(
      title: "Cart Events",
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
              child: TextField(
                decoration: InputDecoration(
                  hintText: "FullName",
                  border: OutlineInputBorder(),
                ),
                controller: codeController,
              ),
            ),
            SizedBox(width: 10),
            Expanded(
              child: TextField(
                decoration: InputDecoration(
                  hintText: "ProductName",
                  border: OutlineInputBorder(),
                ),
                controller: searchController,
              ),
            ),
            SizedBox(width: 10),
            ElevatedButton(
              onPressed: () async {
                var filter = {
                  "userFullName": codeController.text,
                  "productName": searchController.text,
                };
                debugPrint(filter.toString());
                var cartEvents = await cartEventProvider.getAsync(filter: filter);

                this.cartEvents = cartEvents;
                setState(() {});
              },
              child: Text("Search"),
            ),
         
          ],
        ));
  }
  

  Widget _buildResultView() {
    return Expanded(child: Container(
      width: double.infinity,
      child: SingleChildScrollView(
        child: DataTable(
        columns: [
          DataColumn(label: Text("FullName")),
          DataColumn(label: Text("ProductName")),
          DataColumn(label: Text("Type")), 
          DataColumn(label: Text("CreatedAt")),
        ],
        rows: cartEvents?.map((e) => DataRow(
          cells: [
            DataCell(Text(e.fullName)),
            DataCell(Text(e.productName)),
            DataCell(Text(e.type)),
            DataCell(Text(e.createdAt?.toString() ?? '')),
          ])).toList() ?? [],
      ),
      ),
    ));
  }

}
