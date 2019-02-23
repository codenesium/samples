import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import SpeciesMapper from './speciesMapper';
import SpeciesViewModel from './speciesViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { BreedTableComponent } from '../shared/breedTable';

interface SpeciesDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface SpeciesDetailComponentState {
  model?: SpeciesViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class SpeciesDetailComponent extends React.Component<
  SpeciesDetailComponentProps,
  SpeciesDetailComponentState
> {
  state = {
    model: new SpeciesViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Species + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Species +
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
          let response = resp.data as Api.SpeciesClientResponseModel;

          console.log(response);

          let mapper = new SpeciesMapper();

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
            <div>
              <h3>id</h3>
              <p>{String(this.state.model!.id)}</p>
            </div>
            <div>
              <h3>name</h3>
              <p>{String(this.state.model!.name)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>Breeds</h3>
            <BreedTableComponent
              id={this.state.model!.id}
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Species +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.Breeds
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

export const WrappedSpeciesDetailComponent = Form.create({
  name: 'Species Detail',
})(SpeciesDetailComponent);


/*<Codenesium>
    <Hash>1c0be1c92234091d3df4e62ec6dedc18</Hash>
</Codenesium>*/