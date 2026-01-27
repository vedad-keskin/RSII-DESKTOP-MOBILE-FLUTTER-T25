import 'package:ecommerce_mobile/layouts/master_screen.dart';
import 'package:ecommerce_mobile/model/search_result.dart';
import 'package:ecommerce_mobile/model/user_activity.dart';
import 'package:ecommerce_mobile/providers/user_activity_provider.dart';
import 'package:ecommerce_mobile/screens/frmNewActivityIB180079.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

class FrmActivitiesIB180079 extends StatefulWidget {
  const FrmActivitiesIB180079({super.key});

  @override
  State<FrmActivitiesIB180079> createState() => _FrmActivitiesIB180079State();
}

class _FrmActivitiesIB180079State extends State<FrmActivitiesIB180079> {
  late UserActivityProvider userActivityProvider;

  TextEditingController searchController = TextEditingController();

  SearchResult<UserActivity>? userActivities;

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
    userActivityProvider = context.read<UserActivityProvider>();
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreen(
      title: "User Activies",
      child: Center(
        child: Column(
          children: [
            _buildSearch(),
            _buildResultView(),
            Text("Number of points: ${calculateTotalPoints().toString()}")
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
                  hintText: "Status",
                  border: OutlineInputBorder(),
                ),
                controller: searchController,
              ),
            ),
            SizedBox(width: 10),
            ElevatedButton(
              onPressed: () async {
                var filter = {
                  "status": searchController.text,
                };
                debugPrint(filter.toString());
                var userActivities = await userActivityProvider.get(filter: filter);


                this.userActivities = userActivities;
                setState(() {});
              },
              child: Text("Search"),
            ),
            SizedBox(width: 10),
            ElevatedButton(
              onPressed: () {
                Navigator.push(context, MaterialPageRoute(builder: (context) => FrmNewActivityIB180079()));
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
          DataColumn(label: Text("Full Name")),
          DataColumn(label: Text("Activiy")),
          DataColumn(label: Text("Status")), 
          DataColumn(label: Text("Due Date")),
          DataColumn(label: Text("Points")),
        ],
        rows: userActivities?.items?.map((e) => DataRow(
          // onSelectChanged: (value) {
          //   Navigator.push(context, MaterialPageRoute(builder: (context) => ProductDetailsScreen(product: e)));
          // },
          cells: [
            DataCell(Text(e.userFullName)),
            DataCell(Text(e.activityName)),
            DataCell(Text(e.status)),
            DataCell(Text(e.dueDate.toIso8601String())),
            DataCell(Text(e.numberOfPoints.toString()))
          ])).toList() ?? [],
      ),
      ),
    ));
  }


   int calculateTotalPoints(){

      if(userActivities?.items == null){

          return 0;
          
      }

      int sum = 0;

      for(var activity in userActivities!.items!){

          sum += activity.numberOfPoints;

      }
    
    return sum;

   }



}
