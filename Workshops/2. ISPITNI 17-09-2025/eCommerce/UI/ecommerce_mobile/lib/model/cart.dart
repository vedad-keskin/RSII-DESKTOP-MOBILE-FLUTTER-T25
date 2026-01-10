
import 'package:ecommerce_mobile/model/cart_item.dart';
import 'package:ecommerce_mobile/model/product.dart';
import 'package:json_annotation/json_annotation.dart';

part 'cart.g.dart';

@JsonSerializable()
class Cart {
    final int id;
    final int userId;
    List<CartItem> items = [];


  Cart({
    this.id = 0,
    this.userId = 0
  });

    factory Cart.fromJson(Map<String, dynamic> json) => _$CartFromJson(json);

  Map<String, dynamic> toJson() => _$CartToJson(this);

}

