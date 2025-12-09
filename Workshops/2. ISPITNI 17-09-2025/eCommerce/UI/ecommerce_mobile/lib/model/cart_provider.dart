import 'dart:convert';
import 'package:ecommerce_mobile/model/cart.dart';
import 'package:ecommerce_mobile/model/product.dart';
import 'package:ecommerce_mobile/providers/auth_provider.dart';
import 'package:flutter/widgets.dart';
import 'package:collection/collection.dart';
import 'package:http/http.dart' as http;

class CartProvider with ChangeNotifier {
  Cart cart = Cart();
  static String? _baseUrl;

  CartProvider() {
    _baseUrl = const String.fromEnvironment("baseUrl",
        defaultValue: "https://localhost:7093/api/");
  }

  Map<String, String> _createHeaders() {
    String username = AuthProvider.username ?? "";
    String password = AuthProvider.password ?? "";

    String basicAuth =
        "Basic ${base64Encode(utf8.encode('$username:$password'))}";

    return {
      "Content-Type": "application/json",
      "Authorization": basicAuth
    };
  }

  Future<void> loadCart() async {
    try {
      var uri = Uri.parse("${_baseUrl}cart");
      var headers = _createHeaders();
      var response = await http.get(uri, headers: headers);
      
      if (response.statusCode < 299) {
        var data = jsonDecode(response.body);
        cart.items = (data['items'] as List?)
            ?.map((e) => CartItem(
                  Product.fromJson(e['product']),
                  e['count'] ?? 1,
                  id: 0,
                ))
            .toList() ?? [];
        notifyListeners();
      }
    } catch (e) {
      print("Error loading cart: $e");
    }
  }

  Future<void> addToCart(Product product) async {
    try {
      var uri = Uri.parse("${_baseUrl}cart/items");
      var headers = _createHeaders();
      var body = jsonEncode({
        'productId': product.id,
        'quantity': 1,
      });
      
      var response = await http.post(uri, headers: headers, body: body);
      
      if (response.statusCode < 299) {
        await loadCart();
      }
    } catch (e) {
      print("Error adding to cart: $e");
    }
  }

  Future<void> removeFromCart(Product product) async {
    try {
      var cartItem = findInCart(product);
      if (cartItem == null || cartItem.id == 0) return;
      
      var uri = Uri.parse("${_baseUrl}cart/items/${cartItem.id}");
      var headers = _createHeaders();
      
      var response = await http.delete(uri, headers: headers);
      
      if (response.statusCode < 299) {
        await loadCart();
      }
    } catch (e) {
      print("Error removing from cart: $e");
    }
  }

  CartItem? findInCart(Product product) {
    CartItem? item = cart.items.firstWhereOrNull((item) => item.product.id == product.id);
    return item;
  }
}