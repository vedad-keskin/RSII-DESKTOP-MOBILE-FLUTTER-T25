import 'package:json_annotation/json_annotation.dart';

part 'user_activity.g.dart';

@JsonSerializable()
class UserActivity {
  final String userFullName;
  final String activityName;
  final String status;
  final DateTime dueDate;

  UserActivity({
    this.userFullName = '',
    this.activityName = '',
    this.status = '',
    required this.dueDate
  });

  factory UserActivity.fromJson(Map<String, dynamic> json) => _$UserActivityFromJson(json);

  Map<String, dynamic> toJson() => _$UserActivityToJson(this);
} 