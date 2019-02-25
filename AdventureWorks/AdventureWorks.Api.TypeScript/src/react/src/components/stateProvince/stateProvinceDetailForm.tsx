import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import StateProvinceMapper from './stateProvinceMapper';
import StateProvinceViewModel from './stateProvinceViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { AddressTableComponent } from '../shared/addressTable';

interface StateProvinceDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface StateProvinceDetailComponentState {
  model?: StateProvinceViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class StateProvinceDetailComponent extends React.Component<
  StateProvinceDetailComponentProps,
  StateProvinceDetailComponentState
> {
  state = {
    model: new StateProvinceViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.StateProvinces + '/edit/' + this.state.model!.stateProvinceID
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.StateProvinces +
          '/' +
          this.props.match.params.id,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.StateProvinceClientResponseModel;

          console.log(response);

          let mapper = new StateProvinceMapper();

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          console.log(error);
          this.setState({
            model: undefined,
            loading: false,
            loaded: true,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
  }

  render() {
    let message: JSX.Element = <div />;
    if (this.state.errorOccurred) {
      message = <Alert message={this.state.errorMessage} type="error" />;
    }

    if (this.state.loading) {
      return <Spin size="large" />;
    } else if (this.state.loaded) {
      return (
        <div>
          <Button
            style={{ float: 'right' }}
            type="primary"
            onClick={(e: any) => {
              this.handleEditClick(e);
            }}
          >
            <i className="fas fa-edit" />
          </Button>
          <div>
            <div style={{ marginBottom: '10px' }}>
              <h3>CountryRegionCode</h3>
              <p>
                {String(
                  this.state.model!.countryRegionCodeNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div>
              <h3>IsOnlyStateProvinceFlag</h3>
              <p>{String(this.state.model!.isOnlyStateProvinceFlag)}</p>
            </div>
            <div>
              <h3>ModifiedDate</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
            </div>
            <div>
              <h3>Name</h3>
              <p>{String(this.state.model!.name)}</p>
            </div>
            <div>
              <h3>rowguid</h3>
              <p>{String(this.state.model!.rowguid)}</p>
            </div>
            <div>
              <h3>StateProvinceCode</h3>
              <p>{String(this.state.model!.stateProvinceCode)}</p>
            </div>
            <div>
              <h3>StateProvinceID</h3>
              <p>{String(this.state.model!.stateProvinceID)}</p>
            </div>
            <div>
              <h3>TerritoryID</h3>
              <p>{String(this.state.model!.territoryID)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>Addresses</h3>
            <AddressTableComponent
              addressID={this.state.model!.addressID}
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.StateProvinces +
                '/' +
                this.state.model!.stateProvinceID +
                '/' +
                ApiRoutes.Addresses
              }
            />
          </div>
        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedStateProvinceDetailComponent = Form.create({
  name: 'StateProvince Detail',
})(StateProvinceDetailComponent);


/*<Codenesium>
    <Hash>47f3df3589b4061063a27a43c6ae8a9b</Hash>
</Codenesium>*/