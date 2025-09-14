// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'user_activity.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

UserActivity _$UserActivityFromJson(Map<String, dynamic> json) => UserActivity(
      userFullName: json['userFullName'] as String? ?? '',
      activityName: json['activityName'] as String? ?? '',
      status: json['status'] as String? ?? '',
      dueDate: DateTime.parse(json['dueDate'] as String),
      numberOfPoints: (json['numberOfPoints'] as num?)?.toInt() ?? 0,
    );

Map<String, dynamic> _$UserActivityToJson(UserActivity instance) =>
    <String, dynamic>{
      'userFullName': instance.userFullName,
      'activityName': instance.activityName,
      'status': instance.status,
      'dueDate': instance.dueDate.toIso8601String(),
      'numberOfPoints': instance.numberOfPoints,
    };
