import 'package:json_annotation/json_annotation.dart';

part 'cart_event.g.dart';

@JsonSerializable()
class CartEvent {
  final String fullName;
  final String productName;
  final String type;
  final DateTime? createdAt;

  CartEvent({
    this.fullName = '',
    this.productName = '',
    this.type = '',
    this.createdAt,
  });

  factory CartEvent.fromJson(Map<String, dynamic> json) => _$CartEventFromJson(json);

  Map<String, dynamic> toJson() => _$CartEventToJson(this);
} 