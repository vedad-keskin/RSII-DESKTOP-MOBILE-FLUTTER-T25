// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'cart_event.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

CartEvent _$CartEventFromJson(Map<String, dynamic> json) => CartEvent(
      fullName: json['fullName'] as String? ?? '',
      productName: json['productName'] as String? ?? '',
      type: json['type'] as String? ?? '',
      createdAt: json['createdAt'] == null
          ? null
          : DateTime.parse(json['createdAt'] as String),
    );

Map<String, dynamic> _$CartEventToJson(CartEvent instance) => <String, dynamic>{
      'fullName': instance.fullName,
      'productName': instance.productName,
      'type': instance.type,
      'createdAt': instance.createdAt?.toIso8601String(),
    };
