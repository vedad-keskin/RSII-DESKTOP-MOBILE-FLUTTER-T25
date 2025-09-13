import 'package:json_annotation/json_annotation.dart';

part 'activity.g.dart';

@JsonSerializable()
class Activity {
  final int id;
  final String name;
  final String description;
  final DateTime dueDate;

  Activity({
    this.id = 0,
    this.name = '',
    this.description = '',
    required this.dueDate
  });

  factory Activity.fromJson(Map<String, dynamic> json) => _$ActivityFromJson(json);

  Map<String, dynamic> toJson() => _$ActivityToJson(this);
} 