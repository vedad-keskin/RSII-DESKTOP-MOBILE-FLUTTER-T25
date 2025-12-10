import 'dart:convert';

import 'package:ecommerce_mobile/model/cart.dart';
import 'package:ecommerce_mobile/model/cart_item.dart';
import 'package:ecommerce_mobile/model/product.dart';
import 'package:flutter/widgets.dart';
import 'package:collection/collection.dart';
import 'package:http/http.dart' as http;

class CartProvider with ChangeNotifier {
  Cart cart = Cart();

  static int userId = 0;

  static String? _baseUrl;

  CartProvider() {
 
    _baseUrl = const String.fromEnvironment("baseUrl",
        defaultValue: "https://localhost:7093/api/Cart");
  }

  Future<Cart> getAsync(int userId) async {

  //  try{
  var url = "$_baseUrl/$userId"; // https://localhost:7093/api/Cart/2


    var uri = Uri.parse(url);


  

    var response = await http.get(uri);
    

      var data = jsonDecode(response.body);
  
      cart = Cart.fromJson(data);
       
    notifyListeners();

      return cart;

  //  }catch(e){


  //   cart = Cart();

  //   notifyListeners();

  //   return cart;

  //  }

  




 
  }

    Future<int> getUserIdAsync(String username) async {


    var url = "$_baseUrl/$username/me"; // https://localhost:7093/api/Cart/2


    var uri = Uri.parse(url);


  

    var response = await http.get(uri);

    var data = jsonDecode(response.body);
  
       
    return data;  

 
  }


   Future<void> addItemAsync(int productId) async {
  
    var url = "$_baseUrl/$userId/$productId"; // https://localhost:7093/api/Cart/2/8


    var uri = Uri.parse(url);


    await http.post(uri);


    
    notifyListeners();
  }


  Future<void> removeItemAsync(int productId) async
  
   {
     var url = "$_baseUrl/$userId/$productId"; // https://localhost:7093/api/Cart/2/8


    var uri = Uri.parse(url);


    await http.delete(uri);


    notifyListeners();
  }

    Future<void> clearCartAysnc() async{

     var url = "$_baseUrl/$userId"; // https://localhost:7093/api/Cart/2


    var uri = Uri.parse(url);


    await http.delete(uri);

    cart = Cart();

    notifyListeners();
  }













  CartItem? findInCart(Product product) {
    CartItem? item = cart.items.firstWhereOrNull((item) => item.product.id == product.id);
    return item;
  }
}