import 'dart:convert';
import 'package:ecommerce_mobile/model/favoriti.dart';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;

class FavoritiProvider with ChangeNotifier  {

  static int userId = 0;

  static String? _baseUrl;

  FavoritiProvider() {
 
    _baseUrl = const String.fromEnvironment("baseUrl",
        defaultValue: "https://localhost:7093/Favoriti");

  }


  Future<List<Favoriti>> getFavoriti({dynamic filter}) async {


    var url = "${_baseUrl}";

    if (filter != null) {
      var queryString = getQueryString(filter);
      url = "$url?$queryString";
    }

    var uri = Uri.parse(url);

    var response = await http.get(uri);

    
      var data = jsonDecode(response.body);


      var result = List<Favoriti>.from(data.map((e) => Favoriti.fromJson(e)));


return result;

  }


  Future<bool> addFavourites(int userId, int productId) async {
    var url = "${_baseUrl}/$userId/$productId";
    var uri = Uri.parse(url);
    var response = await http.post(uri);
    var data = jsonDecode(response.body);
    return data == true;
  }

  Future<int> getUserIdAsync(String username) async {


    var url = "$_baseUrl/$username/me"; // https://localhost:7093/api/Cart/2


    var uri = Uri.parse(url);


  

    var response = await http.get(uri);

    var data = jsonDecode(response.body);
  
       
    return data;  

 
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


  Future<bool> removeFavourites(int userId, int productId) async {
    var url = "${_baseUrl}/$userId/$productId";
    var uri = Uri.parse(url);
    var response = await http.delete(uri);
    var data = jsonDecode(response.body);
    return data == true;
  }
}
