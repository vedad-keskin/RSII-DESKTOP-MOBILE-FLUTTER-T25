// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'favoriti.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

FavoritiIB180079 _$FavoritiIB180079FromJson(Map<String, dynamic> json) =>
    FavoritiIB180079(
      id: (json['id'] as num?)?.toInt() ?? 0,
      userFullName: json['userFullName'] as String? ?? '',
      productName: json['productName'] as String? ?? '',
      createdAt: json['createdAt'] == null
          ? null
          : DateTime.parse(json['createdAt'] as String),
    );

Map<String, dynamic> _$FavoritiIB180079ToJson(FavoritiIB180079 instance) =>
    <String, dynamic>{
      'id': instance.id,
      'userFullName': instance.userFullName,
      'productName': instance.productName,
      'createdAt': instance.createdAt?.toIso8601String(),
    };
