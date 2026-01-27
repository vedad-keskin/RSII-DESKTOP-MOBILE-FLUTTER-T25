import 'dart:convert';
import 'dart:io';

import 'package:ecommerce_mobile/layouts/master_screen.dart';
import 'package:ecommerce_mobile/model/activity.dart';
import 'package:ecommerce_mobile/model/product.dart';
import 'package:ecommerce_mobile/model/product_type.dart';
import 'package:ecommerce_mobile/model/search_result.dart';
import 'package:ecommerce_mobile/model/unit_of_measure.dart';
import 'package:ecommerce_mobile/model/user.dart';
import 'package:ecommerce_mobile/model/user_activity.dart';
import 'package:ecommerce_mobile/providers/activity_provider.dart';
import 'package:ecommerce_mobile/providers/product_provider.dart';
import 'package:ecommerce_mobile/providers/product_type_provider.dart';
import 'package:ecommerce_mobile/providers/unit_of_measure_provider.dart';
import 'package:ecommerce_mobile/providers/user_activity_provider.dart';
import 'package:ecommerce_mobile/providers/user_provider.dart';
import 'package:ecommerce_mobile/screens/frmActivitiesIB180079.dart';
import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';
import 'package:provider/provider.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
// import 'package:file_picker/file_picker.dart';

class FrmNewActivityIB180079  extends StatefulWidget {
  UserActivity? userActivity;
  FrmNewActivityIB180079({super.key});

  @override
  State<FrmNewActivityIB180079> createState() => _FrmNewActivityIB180079State();
}

class _FrmNewActivityIB180079State extends State<FrmNewActivityIB180079> {
  final formKey = GlobalKey<FormBuilderState>();

  late UserActivityProvider userActivityProvider;
  late ActivityProvider activityProvider;
  late UserProvider userProvider;

  SearchResult<Activity>? activities;
  SearchResult<User>? users;
  bool isLoading = true;

  @override
  void initState() {
    super.initState();
    userActivityProvider = Provider.of<UserActivityProvider>(context, listen: false);
    activityProvider =
        Provider.of<ActivityProvider>(context, listen: false);
    userProvider =
        Provider.of<UserProvider>(context, listen: false);



    initFormData();
  }

  initFormData() async {
    activities = await activityProvider.get();
    users = await userProvider.get();

    setState(() {
      isLoading = false;
    });
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreen(
      title: "New User Activity",
      child: Column(children: [
        _buildForm(),
        _buildSaveButton()
      ],),
    );
  }

  Widget _buildSaveButton() {
    return ElevatedButton(
      onPressed: () async {
        formKey.currentState?.saveAndValidate();
        if (formKey.currentState?.validate() ?? false) {
          print(formKey.currentState?.value.toString());
          var request = Map.from(formKey.currentState?.value ?? {});
          if (widget.userActivity == null) {
            widget.userActivity = await userActivityProvider.insert(request);
            

                Navigator.push(context, MaterialPageRoute(builder: (context) => FrmActivitiesIB180079()));



          } else {
            //widget.userActivity = await userActivityProvider.update(widget.userActivity!.id, request);
          }
        }
      },
      child: Text("Save"),
    );
  }
  
  File? _image;
  String? _base64Image;

  Widget _buildForm() {
    if (isLoading) {
      return Center(child: CircularProgressIndicator());
    }

    return FormBuilder(
        key: formKey,
        //initialValue: _initalValue,
        child: Padding(
          padding: const EdgeInsets.all(16.0),
          child: Column(
            children: [
              FormBuilderTextField(
                name: "note",
                decoration: InputDecoration(labelText: "Note"),
              ),
              Row(
                children: [
                  Expanded(
                      child: FormBuilderDropdown(
                    name: "activityId",
                    decoration: InputDecoration(labelText: "Activity"),
                    items: activities?.items
                            ?.map((e) => DropdownMenuItem(
                                value: e.id, child: Text(e.name)))
                            .toList() ??
                        [],
                  )),
                  Expanded(
                      child: FormBuilderDropdown(
                    name: "userId",
                    decoration: InputDecoration(labelText: "Users"),
                    items: users?.items
                            ?.map((e) => DropdownMenuItem(
                                value: e.id, child: Text("${e.firstName} ${e.lastName}")))
                            .toList() ??
                        [],
                  ))
                ],
              ),

              // Row(
              //   children: [
              //     Expanded(
              //         child: FormBuilderField(
              //             name: "image",
              //             builder: (FormFieldState<dynamic> field) {
              //               return TextButton(
              //                 onPressed: () async {
              //                   FilePickerResult? result =
              //                       await FilePicker.platform.pickFiles();
              //                   if (result != null) {
              //                     _image = File(result.files.single.path!);
              //                     _base64Image = base64Encode(_image!.readAsBytesSync());
              //                   }
              //                 },
              //                 child: Text("Upload Image"),
              //               );
              //             }))
              //   ],
              // )
            ],
          ),
        ));
  }
}
