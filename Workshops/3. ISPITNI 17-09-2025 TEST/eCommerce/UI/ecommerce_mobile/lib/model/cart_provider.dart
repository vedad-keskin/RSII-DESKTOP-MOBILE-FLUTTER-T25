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

  static String? _baseUrl;

  CartProvider() {
    _baseUrl = const String.fromEnvironment("baseUrl",
        defaultValue: "https://localhost:7093/api/Cart");
  }

   Future<Cart> getCart(int userId) async {
    final url = "$_baseUrl/$userId";   // <-- IMPORTANT

      final uri = Uri.parse(url);


    final response = await http.get(uri);

        final data = jsonDecode(response.body);
        cart = Cart.fromJson(data);   // <-- Update the cart property
        notifyListeners();  // <-- Notify listeners to update UI
        return cart;
     
   
  }










  addToCart(Product product) {
    if (findInCart(product) != null) {
      findInCart(product)?.count++;
    } else {
      cart.items.add(CartItem(product, 1));
    }
    
    notifyListeners();
  }

  removeFromCart(Product product) {
    cart.items.removeWhere((item) => item.product.id == product.id);
    notifyListeners();
  }

  CartItem? findInCart(Product product) {
    CartItem? item = cart.items.firstWhereOrNull((item) => item.product.id == product.id);
    return item;
  }
}