// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'favoriti.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Favoriti _$FavoritiFromJson(Map<String, dynamic> json) => Favoriti(
      id: (json['id'] as num?)?.toInt() ?? 0,
      userFullName: json['userFullName'] as String? ?? '',
      productName: json['productName'] as String? ?? '',
      createdAt: json['createdAt'] == null
          ? null
          : DateTime.parse(json['createdAt'] as String),
    );

Map<String, dynamic> _$FavoritiToJson(Favoriti instance) => <String, dynamic>{
      'id': instance.id,
      'userFullName': instance.userFullName,
      'productName': instance.productName,
      'createdAt': instance.createdAt?.toIso8601String(),
    };
