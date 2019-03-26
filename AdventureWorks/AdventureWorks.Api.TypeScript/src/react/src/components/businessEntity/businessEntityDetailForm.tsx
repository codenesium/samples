import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import BusinessEntityMapper from './businessEntityMapper';
import BusinessEntityViewModel from './businessEntityViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { BusinessEntityAddressTableComponent } from '../shared/businessEntityAddressTable';
import { BusinessEntityContactTableComponent } from '../shared/businessEntityContactTable';
import { PersonTableComponent } from '../shared/personTable';

interface BusinessEntityDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface BusinessEntityDetailComponentState {
  model?: BusinessEntityViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class BusinessEntityDetailComponent extends React.Component<
  BusinessEntityDetailComponentProps,
  BusinessEntityDetailComponentState
> {
  state = {
    model: new BusinessEntityViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.BusinessEntities +
        '/edit/' +
        this.state.model!.businessEntityID
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.BusinessEntityClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.BusinessEntities +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new BusinessEntityMapper();

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
            <div>
              <h3>Modified Date</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
            </div>
            <div>
              <h3>Rowguid</h3>
              <p>{String(this.state.model!.rowguid)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>BusinessEntityAddresses</h3>
            <BusinessEntityAddressTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.BusinessEntities +
                '/' +
                this.state.model!.businessEntityID +
                '/' +
                ApiRoutes.BusinessEntityAddresses
              }
            />
          </div>
          <div>
            <h3>BusinessEntityContacts</h3>
            <BusinessEntityContactTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.BusinessEntities +
                '/' +
                this.state.model!.businessEntityID +
                '/' +
                ApiRoutes.BusinessEntityContacts
              }
            />
          </div>
          <div>
            <h3>People</h3>
            <PersonTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.BusinessEntities +
                '/' +
                this.state.model!.businessEntityID +
                '/' +
                ApiRoutes.People
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

export const WrappedBusinessEntityDetailComponent = Form.create({
  name: 'BusinessEntity Detail',
})(BusinessEntityDetailComponent);


/*<Codenesium>
    <Hash>e5f76b79186101f35a58def4340f1229</Hash>
</Codenesium>*/