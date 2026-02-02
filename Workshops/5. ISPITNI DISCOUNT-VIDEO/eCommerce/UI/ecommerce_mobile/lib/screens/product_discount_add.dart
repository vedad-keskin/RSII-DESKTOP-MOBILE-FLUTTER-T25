import 'dart:convert';
import 'dart:io';

import 'package:ecommerce_mobile/layouts/master_screen.dart';
import 'package:ecommerce_mobile/model/product.dart';
import 'package:ecommerce_mobile/model/product_discount.dart';
import 'package:ecommerce_mobile/model/product_type.dart';
import 'package:ecommerce_mobile/model/search_result.dart';
import 'package:ecommerce_mobile/model/unit_of_measure.dart';
import 'package:ecommerce_mobile/providers/product_discount_provider.dart';
import 'package:ecommerce_mobile/providers/product_provider.dart';
import 'package:ecommerce_mobile/providers/product_type_provider.dart';
import 'package:ecommerce_mobile/providers/unit_of_measure_provider.dart';
import 'package:ecommerce_mobile/screens/product_discount_list.dart';
import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';
import 'package:provider/provider.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
// import 'package:file_picker/file_picker.dart';

class ProductDiscountAdd extends StatefulWidget {
  ProductDiscount? productDiscount;
  ProductDiscountAdd({super.key, this.productDiscount});

  @override
  State<ProductDiscountAdd> createState() => _ProductDiscountAddState();
}

class _ProductDiscountAddState extends State<ProductDiscountAdd> {
  final formKey = GlobalKey<FormBuilderState>();

  Map<String, dynamic> _initalValue = {};

  late ProductDiscountProvider productDiscountProvider;
  late ProductProvider productProvider;


  SearchResult<Product>? products;

  bool isLoading = true;

  @override
  void initState() {
    super.initState();
    productProvider = Provider.of<ProductProvider>(context, listen: false);
    productDiscountProvider = Provider.of<ProductDiscountProvider>(context, listen: false);


    _initalValue = {
      "productId": widget.productDiscount?.productId,
      "discount": widget.productDiscount?.discount.toString(),
      "dateFrom": widget.productDiscount?.dateFrom,
      "dateTo": widget.productDiscount?.dateTo,

    };
    print("widget.productDiscount");
    print(_initalValue);

    initFormData();
  }

  initFormData() async {
    products = await productProvider.get();

    setState(() {
      isLoading = false;
    });
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreen(
      title: "Product Discount Details",
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


            try {

          var request = Map.from(formKey.currentState?.value ?? {});

          var from = request['dateFrom'] as DateTime?;
          var to = request['dateTo'] as DateTime?;

          request['dateFrom'] = from?.toIso8601String();
          request['dateTo'] = to?.toIso8601String();


          if (widget.productDiscount == null) {
            widget.productDiscount = await productDiscountProvider.insert(request);
          } else {
            widget.productDiscount = await productDiscountProvider.update(widget.productDiscount!.id, request);
          }


           Navigator.push(context, MaterialPageRoute(builder: (context) => ProductDiscountList()));

          } catch (e) {
          
          ScaffoldMessenger.of(context).showSnackBar(
                  SnackBar(content: Text(e.toString())),
                );

    }

        }
      },
      child: Text("Save"),
    );
  }
  

  Widget _buildForm() {
    if (isLoading) {
      return Center(child: CircularProgressIndicator());
    }

    return FormBuilder(
        key: formKey,
        initialValue: _initalValue,
        child: Padding(
          padding: const EdgeInsets.all(16.0),
          child: Column(
            children: [
              FormBuilderTextField(
                name: "discount",
                decoration: InputDecoration(labelText: "Discount"),
              ),
              SizedBox(height: 8),
             
              Row(
                children: [
                  Expanded(
                      child: FormBuilderDropdown(
                    name: "productId",
                    decoration: InputDecoration(labelText: "Products"),
                    items: products?.items
                            ?.map((e) => DropdownMenuItem(
                                value: e.id, child: Text(e.name)))
                            .toList() ??
                        [],
                  )),
               
                ],
              ),
              SizedBox(height: 8),

              FormBuilderDateTimePicker(
              name: "dateFrom",
              decoration: InputDecoration(labelText: "Date From"),
              firstDate: DateTime(2020),
              lastDate: DateTime(2050),
              initialValue: widget.productDiscount?.dateFrom ?? DateTime.now(),
              inputType: InputType.date,

              ),
 
              SizedBox(height: 8),

              FormBuilderDateTimePicker(
              name: "dateTo",
              decoration: InputDecoration(labelText: "Date To"),
              firstDate: DateTime(2020),
              lastDate: DateTime(2050),
              initialValue: widget.productDiscount?.dateTo ?? DateTime.now(),
              inputType: InputType.date,

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
