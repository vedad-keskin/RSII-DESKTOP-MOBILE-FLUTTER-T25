import 'package:ecommerce_mobile/model/cart.dart';
import 'package:ecommerce_mobile/model/cart_item.dart';
import 'package:ecommerce_mobile/model/product.dart';
import 'package:flutter/widgets.dart';
import 'package:collection/collection.dart';

import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;

class CartProvider with ChangeNotifier {
  Cart cart = Cart();

  static int userId = 0;

  static String? _baseUrl;

  CartProvider() {
    _baseUrl = const String.fromEnvironment("baseUrl",
        defaultValue: "https://localhost:7093/api/Cart");
  }

   Future<Cart> getCart(int userId) async {
    try {
      final url = "$_baseUrl/$userId";   // <-- IMPORTANT

      final uri = Uri.parse(url);

      final response = await http.get(uri);

      if (response.statusCode == 200) {
        final data = jsonDecode(response.body);
        cart = Cart.fromJson(data);   // <-- Update the cart property
        notifyListeners();  // <-- Notify listeners to update UI
        return cart;
      } else {
        // Cart not found or other error - return empty cart
        cart = Cart();
        notifyListeners();
        return cart;
      }
    } catch (e) {
      // Handle any exceptions (network errors, parsing errors, etc.)
      cart = Cart();
      notifyListeners();
      return cart;
    }
  }


  Future<int> getUserId(String username) async {
    final url = "$_baseUrl/$username/me";   // <-- IMPORTANT

      final uri = Uri.parse(url);


       final response = await http.get(uri);

        final data = jsonDecode(response.body);

        return data;
     
   
  }









  Future<void> addToCart(int productId) async {
   
    final url = "$_baseUrl/$userId/$productId";
    final uri = Uri.parse(url);


    await http.post(uri);
     

      notifyListeners();

  }

  Future<void> removeFromCart(int productId) async {
    final url = "$_baseUrl/$userId/$productId";
    final uri = Uri.parse(url);

    await http.delete(uri);
    
    notifyListeners();
  }

  Future<void> clearCart() async {
    final url = "$_baseUrl/$userId";
    final uri = Uri.parse(url);

    await http.delete(uri);
    
    cart = Cart();
    notifyListeners();
  }

  CartItem? findInCart(Product product) {
    CartItem? item = cart.items.firstWhereOrNull((item) => item.product.id == product.id);
    return item;
  }
}