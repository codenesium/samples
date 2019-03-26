import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import StateProvinceMapper from './stateProvinceMapper';
import StateProvinceViewModel from './stateProvinceViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
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
      .get<Api.StateProvinceClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.StateProvinces +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new StateProvinceMapper();

        this.setState({
          model: mapper.mapApiResponseToViewModel(response.data),
          loading: false,
          loaded: true,
          errorOccurred: false,
          errorMessage: '',
        });
      })
      .catch((error: AxiosError) => {
        GlobalUtilities.logError(error);

        if (error.response && error.response.status == 422) {
          this.setState({
            ...this.state,
            errorOccurred: false,
            errorMessage: '',
          });
        } else {
          this.setState({
            ...this.state,
            errorOccurred: true,
            errorMessage: 'Error Occurred',
          });
        }
      });
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
              <h3>Country Region Code</h3>
              <p>
                {String(
                  this.state.model!.countryRegionCodeNavigation &&
                    this.state.model!.countryRegionCodeNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div>
              <h3>Is Only State Province Flag</h3>
              <p>{String(this.state.model!.isOnlyStateProvinceFlag)}</p>
            </div>
            <div>
              <h3>Modified Date</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
            </div>
            <div>
              <h3>Name</h3>
              <p>{String(this.state.model!.name)}</p>
            </div>
            <div>
              <h3>Rowguid</h3>
              <p>{String(this.state.model!.rowguid)}</p>
            </div>
            <div>
              <h3>State Province Code</h3>
              <p>{String(this.state.model!.stateProvinceCode)}</p>
            </div>
            <div>
              <h3>Territory I D</h3>
              <p>{String(this.state.model!.territoryID)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>Addresses</h3>
            <AddressTableComponent
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
    <Hash>3c41cb9c28fbe51b965ec70748a8aa34</Hash>
</Codenesium>*/