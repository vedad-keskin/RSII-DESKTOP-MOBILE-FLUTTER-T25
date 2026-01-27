import 'package:json_annotation/json_annotation.dart';

part 'favoriti.g.dart';

@JsonSerializable()
class Favoriti {
  final int id;
  final String userFullName;
  final String productName;
  final DateTime? createdAt;

  Favoriti({
    this.id = 0,
    this.userFullName = '',
    this.productName = '',
    required this.createdAt,
  });

  factory Favoriti.fromJson(Map<String, dynamic> json) =>
      _$FavoritiFromJson(json);

  Map<String, dynamic> toJson() => _$FavoritiToJson(this);
}