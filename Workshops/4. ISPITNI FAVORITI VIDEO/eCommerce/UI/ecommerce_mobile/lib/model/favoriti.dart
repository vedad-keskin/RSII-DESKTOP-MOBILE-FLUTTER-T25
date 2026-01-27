import 'package:json_annotation/json_annotation.dart';

part 'favoriti.g.dart';

@JsonSerializable()
class FavoritiIB180079 {
  final int id;
  final String userFullName;
  final String productName;
  final DateTime? createdAt;

  FavoritiIB180079({
    this.id = 0,
    this.userFullName = '',
    this.productName = '',
    this.createdAt,
  });

  factory FavoritiIB180079.fromJson(Map<String, dynamic> json) => _$FavoritiIB180079FromJson(json);

  Map<String, dynamic> toJson() => _$FavoritiIB180079ToJson(this);
} 