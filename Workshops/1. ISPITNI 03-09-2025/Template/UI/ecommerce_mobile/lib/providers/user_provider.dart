import 'package:ecommerce_mobile/model/user.dart';
import 'package:ecommerce_mobile/providers/base_provider.dart';

class UserProvider extends BaseProvider<User> {
  UserProvider() :super("Users");

  @override
  User fromJson(dynamic json) {
    return User.fromJson(json);
  }



} 