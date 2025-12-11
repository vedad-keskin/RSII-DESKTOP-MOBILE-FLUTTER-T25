import 'package:ecommerce_mobile/model/cart_event.dart';
import 'package:flutter/widgets.dart';

import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;

class CartEventProvider with ChangeNotifier {


  static String? _baseUrl;

  CartEventProvider() {
    _baseUrl = const String.fromEnvironment("baseUrl",
        defaultValue: "https://localhost:7093/api/CartEvent");
  }

   Future<List<CartEvent>> getAsync({dynamic filter}) async {
 
      var url = "$_baseUrl";   // <-- IMPORTANT

    if (filter != null) {
      var queryString = getQueryString(filter);
      url = "$url?$queryString";
    }

      final uri = Uri.parse(url);

      final response = await http.get(uri);


    var data = jsonDecode(response.body);

    var result = List<CartEvent>.from(data.map((e) => CartEvent.fromJson(e)));

    return result;
  }


  String getQueryString(Map params,
      {String prefix = '&', bool inRecursion = false}) {
    String query = '';
    params.forEach((key, value) {
      if (inRecursion) {
        if (key is int) {
          key = '[$key]';
        } else if (value is List || value is Map) {
          key = '.$key';
        } else {
          key = '.$key';
        }
      }
      if (value is String || value is int || value is double || value is bool) {
        var encoded = value;
        if (value is String) {
          encoded = Uri.encodeComponent(value);
        }
        query += '$prefix$key=$encoded';
      } else if (value is DateTime) {
        query += '$prefix$key=${(value as DateTime).toIso8601String()}';
      } else if (value is List || value is Map) {
        if (value is List) value = value.asMap();
        value.forEach((k, v) {
          query +=
              getQueryString({k: v}, prefix: '$prefix$key', inRecursion: true);
        });
      }
    });
    return query;
  }

}