import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import CountryRegionMapper from './countryRegionMapper';
import CountryRegionViewModel from './countryRegionViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { StateProvinceTableComponent } from '../shared/stateProvinceTable';

interface CountryRegionDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface CountryRegionDetailComponentState {
  model?: CountryRegionViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class CountryRegionDetailComponent extends React.Component<
  CountryRegionDetailComponentProps,
  CountryRegionDetailComponentState
> {
  state = {
    model: new CountryRegionViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.CountryRegions +
        '/edit/' +
        this.state.model!.countryRegionCode
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.CountryRegionClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.CountryRegions +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new CountryRegionMapper();

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
              <h3>Name</h3>
              <p>{String(this.state.model!.name)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>StateProvinces</h3>
            <StateProvinceTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.CountryRegions +
                '/' +
                this.state.model!.countryRegionCode +
                '/' +
                ApiRoutes.StateProvinces
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

export const WrappedCountryRegionDetailComponent = Form.create({
  name: 'CountryRegion Detail',
})(CountryRegionDetailComponent);


/*<Codenesium>
    <Hash>33ad58f479759e3c08a57eedea6a7a9c</Hash>
</Codenesium>*/