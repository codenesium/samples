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

              <MenuItem key="columnSameAsFKTable">
                <Icon type="pie-chart" />
                <span>ColumnSameAsFKTables</span>
                <Link to={ClientRoutes.ColumnSameAsFKTables} />
              </MenuItem>

              <MenuItem key="includedColumnTest">
                <Icon type="rise" />
                <span>IncludedColumnTests</span>
                <Link to={ClientRoutes.IncludedColumnTests} />
              </MenuItem>

              <MenuItem key="person">
                <Icon type="bars" />
                <span>People</span>
                <Link to={ClientRoutes.People} />
              </MenuItem>

              <MenuItem key="rowVersionCheck">
                <Icon type="cloud" />
                <span>RowVersionChecks</span>
                <Link to={ClientRoutes.RowVersionChecks} />
              </MenuItem>

              <MenuItem key="selfReference">
                <Icon type="code" />
                <span>SelfReferences</span>
                <Link to={ClientRoutes.SelfReferences} />
              </MenuItem>

              <MenuItem key="table">
                <Icon type="smile" />
                <span>Tables</span>
                <Link to={ClientRoutes.Tables} />
              </MenuItem>

              <MenuItem key="testAllFieldType">
                <Icon type="laptop" />
                <span>TestAllFieldTypes</span>
                <Link to={ClientRoutes.TestAllFieldTypes} />
              </MenuItem>

              <MenuItem key="testAllFieldTypesNullable">
                <Icon type="mobile" />
                <span>TestAllFieldTypesNullables</span>
                <Link to={ClientRoutes.TestAllFieldTypesNullables} />
              </MenuItem>

              <MenuItem key="timestampCheck">
                <Icon type="paper-clip" />
                <span>TimestampChecks</span>
                <Link to={ClientRoutes.TimestampChecks} />
              </MenuItem>

              <MenuItem key="vPerson">
                <Icon type="setting" />
                <span>VPersons</span>
                <Link to={ClientRoutes.VPersons} />
              </MenuItem>
            </Menu>
          </Sider>
          <Layout>
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
    <Hash>a43d1d12231663888959925ec3b68a52</Hash>
</Codenesium>*/