
import 'package:ecommerce_mobile/model/product.dart';
import 'package:json_annotation/json_annotation.dart';

// class CartItem {
//   CartItem(this.product, this.count);
//   late Product product;
//   late int count;
// }

part 'cart_item.g.dart';

@JsonSerializable()
class CartItem {
  CartItem(this.product, this.count);
  late Product product;
  late int count;



  factory CartItem.fromJson(Map<String, dynamic> json) => _$CartItemFromJson(json);

  Map<String, dynamic> toJson() => _$CartItemToJson(this);

}