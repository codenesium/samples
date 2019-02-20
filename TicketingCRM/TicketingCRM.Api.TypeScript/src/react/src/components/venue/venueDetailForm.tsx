import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { LoadingForm } from '../../lib/components/loadingForm';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import VenueMapper from './venueMapper';
import VenueViewModel from './venueViewModel';
import { Form, Input, Button } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { Alert } from 'antd';

interface VenueDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface VenueDetailComponentState {
  model?: VenueViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class VenueDetailComponent extends React.Component<
  VenueDetailComponentProps,
  VenueDetailComponentState
> {
  state = {
    model: new VenueViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Venues + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Venues +
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
          let response = resp.data as Api.VenueClientResponseModel;

          console.log(response);

          let mapper = new VenueMapper();

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
            loaded: false,
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
      return <LoadingForm />;
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
              <div>address1</div>
              <div>{this.state.model!.address1}</div>
            </div>
            <div>
              <div>address2</div>
              <div>{this.state.model!.address2}</div>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>adminId</h3>
              <div>{this.state.model!.adminIdNavigation!.toDisplay()}</div>
            </div>
            <div>
              <div>email</div>
              <div>{this.state.model!.email}</div>
            </div>
            <div>
              <div>facebook</div>
              <div>{this.state.model!.facebook}</div>
            </div>
            <div>
              <div>name</div>
              <div>{this.state.model!.name}</div>
            </div>
            <div>
              <div>phone</div>
              <div>{this.state.model!.phone}</div>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>provinceId</h3>
              <div>{this.state.model!.provinceIdNavigation!.toDisplay()}</div>
            </div>
            <div>
              <div>website</div>
              <div>{this.state.model!.website}</div>
            </div>
          </div>
          {message}
        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedVenueDetailComponent = Form.create({
  name: 'Venue Detail',
})(VenueDetailComponent);


/*<Codenesium>
    <Hash>f55229c6bd3d17ca13bdf22ffd8d53ea</Hash>
</Codenesium>*/