import 'package:ecommerce_mobile/model/product_discount.dart';
import 'package:ecommerce_mobile/providers/base_provider.dart';

class ProductDiscountProvider extends BaseProvider<ProductDiscount> {
  ProductDiscountProvider() : super("ProductDiscount");

  @override
  ProductDiscount fromJson(dynamic json) {
    return ProductDiscount.fromJson(json);
  }
}