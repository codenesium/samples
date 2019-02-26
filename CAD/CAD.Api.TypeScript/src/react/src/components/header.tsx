import * as React from 'react';
import { Layout, Menu, Breadcrumb, Icon } from 'antd';
import MenuItem from '../../node_modules/antd/lib/menu/MenuItem';
import { Link, RouteComponentProps } from 'react-router-dom';
import { ClientRoutes, Constants } from '../constants';
const { Header, Content, Footer, Sider } = Layout;

const SubMenu = Menu.SubMenu;

interface WrapperHeaderProps {}

interface WrapperHeaderState {
  collapsed: boolean;
}
export const wrapperHeader = (
  Component: React.ComponentClass<any> | React.SFC<any>,
  displayName: string
) => {
  class WrapperHeaderComponent extends React.Component<
    WrapperHeaderProps & RouteComponentProps,
    WrapperHeaderState
  > {
    state = { collapsed: true };

    onCollapse = () => {
      this.setState({ ...this.state, collapsed: !this.state.collapsed });
    };
    render() {
      return (
        <Layout style={{ minHeight: '100vh' }}>
          <Sider
            collapsible
            collapsed={this.state.collapsed}
            onCollapse={this.onCollapse}
          >
            <div className="logo" />
            <Menu theme="dark" defaultSelectedKeys={['1']} mode="inline">
              <MenuItem
                key="Home"
                onClick={() => {
                  this.setState({ ...this.state, collapsed: true });
                }}
              >
                <Icon type="home" />
                <span>Home</span>
                <Link to={'/'} />
              </MenuItem>

              <MenuItem key="address">
                <Icon type="pie-chart" />
                <span>Addresses</span>
                <Link to={ClientRoutes.Addresses} />
              </MenuItem>

              <MenuItem key="call">
                <Icon type="rise" />
                <span>Calls</span>
                <Link to={ClientRoutes.Calls} />
              </MenuItem>

              <MenuItem key="callAssignment">
                <Icon type="bars" />
                <span>CallAssignments</span>
                <Link to={ClientRoutes.CallAssignments} />
              </MenuItem>

              <MenuItem key="callDisposition">
                <Icon type="cloud" />
                <span>CallDispositions</span>
                <Link to={ClientRoutes.CallDispositions} />
              </MenuItem>

              <MenuItem key="callPerson">
                <Icon type="code" />
                <span>CallPersons</span>
                <Link to={ClientRoutes.CallPersons} />
              </MenuItem>

              <MenuItem key="callStatu">
                <Icon type="smile" />
                <span>CallStatus</span>
                <Link to={ClientRoutes.CallStatus} />
              </MenuItem>

              <MenuItem key="callType">
                <Icon type="laptop" />
                <span>CallTypes</span>
                <Link to={ClientRoutes.CallTypes} />
              </MenuItem>

              <MenuItem key="note">
                <Icon type="mobile" />
                <span>Notes</span>
                <Link to={ClientRoutes.Notes} />
              </MenuItem>

              <MenuItem key="officer">
                <Icon type="paper-clip" />
                <span>Officers</span>
                <Link to={ClientRoutes.Officers} />
              </MenuItem>

              <MenuItem key="officerCapability">
                <Icon type="setting" />
                <span>OfficerCapabilities</span>
                <Link to={ClientRoutes.OfficerCapabilities} />
              </MenuItem>

              <MenuItem key="officerRefCapability">
                <Icon type="user" />
                <span>OfficerRefCapabilities</span>
                <Link to={ClientRoutes.OfficerRefCapabilities} />
              </MenuItem>

              <MenuItem key="person">
                <Icon type="home" />
                <span>People</span>
                <Link to={ClientRoutes.People} />
              </MenuItem>

              <MenuItem key="personType">
                <Icon type="camera" />
                <span>PersonTypes</span>
                <Link to={ClientRoutes.PersonTypes} />
              </MenuItem>

              <MenuItem key="unit">
                <Icon type="like" />
                <span>Units</span>
                <Link to={ClientRoutes.Units} />
              </MenuItem>

              <MenuItem key="unitDisposition">
                <Icon type="bulb" />
                <span>UnitDispositions</span>
                <Link to={ClientRoutes.UnitDispositions} />
              </MenuItem>

              <MenuItem key="unitOfficer">
                <Icon type="tool" />
                <span>UnitOfficers</span>
                <Link to={ClientRoutes.UnitOfficers} />
              </MenuItem>

              <MenuItem key="vehicle">
                <Icon type="coffee" />
                <span>Vehicles</span>
                <Link to={ClientRoutes.Vehicles} />
              </MenuItem>

              <MenuItem key="vehicleCapability">
                <Icon type="experiment" />
                <span>VehicleCapabilities</span>
                <Link to={ClientRoutes.VehicleCapabilities} />
              </MenuItem>

              <MenuItem key="vehicleOfficer">
                <Icon type="security-scan" />
                <span>VehicleOfficers</span>
                <Link to={ClientRoutes.VehicleOfficers} />
              </MenuItem>

              <MenuItem key="vehicleRefCapability">
                <Icon type="thunderbolt" />
                <span>VehicleRefCapabilities</span>
                <Link to={ClientRoutes.VehicleRefCapabilities} />
              </MenuItem>
            </Menu>
          </Sider>
          <Layout>
            <Header style={{ background: '#fff', padding: 0 }} />
            <Content style={{ margin: '0 16px' }}>
              <h2>{displayName}</h2>
              <div style={{ padding: 24, background: '#fff', minHeight: 360 }}>
                <Component {...this.props} />
              </div>
            </Content>
            <Footer style={{ textAlign: 'center' }}>Footer</Footer>
          </Layout>
        </Layout>
      );
    }
  }
  return WrapperHeaderComponent;
};


/*<Codenesium>
    <Hash>8b048ee55a2c2b642744e1bd4fbb8815</Hash>
</Codenesium>*/