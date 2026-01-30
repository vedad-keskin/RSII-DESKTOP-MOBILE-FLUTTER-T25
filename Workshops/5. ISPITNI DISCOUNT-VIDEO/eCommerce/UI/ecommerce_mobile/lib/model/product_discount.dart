import 'package:json_annotation/json_annotation.dart';
import 'asset.dart';

part 'product_discount.g.dart';

@JsonSerializable()
class ProductDiscount {
  final int id;
  final int productId;
  final String productName;
  final double productPrice;
  final double discount;
  final double newPrice;
  final DateTime? dateFrom;
  final DateTime? dateTo;
  final List<Asset> assets;

  ProductDiscount({
    this.id = 0,
    this.productId = 0,
    this.productName = '',
    this.productPrice = 0,
    this.discount = 0,
    this.newPrice = 0,
    this.dateFrom,
    this.dateTo,
    this.assets = const [],
  });

  factory ProductDiscount.fromJson(Map<String, dynamic> json) => _$ProductDiscountFromJson(json);

  Map<String, dynamic> toJson() => _$ProductDiscountToJson(this);


}
