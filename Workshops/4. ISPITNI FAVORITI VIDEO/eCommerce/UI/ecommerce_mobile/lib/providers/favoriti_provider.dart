import 'dart:convert';

import 'package:ecommerce_mobile/model/favoriti.dart';
import 'package:ecommerce_mobile/model/product.dart';
import 'package:ecommerce_mobile/model/search_result.dart';
import 'package:ecommerce_mobile/providers/base_provider.dart';
import 'package:flutter/widgets.dart';
import 'package:http/http.dart' as http;
import 'package:ecommerce_mobile/providers/auth_provider.dart';

class FavoritiProvider with ChangeNotifier {

  static String? _baseUrl;

  FavoritiProvider() {

       _baseUrl = const String.fromEnvironment("baseUrl",
        defaultValue: "https://localhost:7093/Favoriti");

  }

    Future<List<FavoritiIB180079>> getAsync({dynamic filter}) async {

    var url = "$_baseUrl"; // https://localhost:7093/Favoriti

    if (filter != null) {
      var queryString = getQueryString(filter);
      url = "$url?$queryString";
    }

    var uri = Uri.parse(url);

    var response = await http.get(uri);

    var data = jsonDecode(response.body);

    return List<FavoritiIB180079>.from(data.map((e) => FavoritiIB180079.fromJson(e)));


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